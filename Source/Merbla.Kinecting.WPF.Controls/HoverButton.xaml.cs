using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Merbla.Kinecting.WPF.Controls
{
    /// <summary>
    ///   Interaction logic for HoverButton.xaml
    /// </summary>
    public partial class HoverButton : UserControl
    {
        #region Fields

        //animation related
        private readonly Duration reverseDuration = new Duration(new TimeSpan(0, 0, 1));
        private Duration hoverDuration = new Duration(new TimeSpan(0, 0, 2));
        private bool isHovering;
        private DoubleAnimation maskAnimation;

        #endregion

        #region Properties

        public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register(
            "BackgroundColor", typeof (Brush), typeof (HoverButton), new PropertyMetadata(Brushes.Red));

        public static readonly DependencyProperty HoverColorProperty = DependencyProperty.Register(
            "HoverColor", typeof (Brush), typeof (HoverButton), new PropertyMetadata(Brushes.White));

        public static readonly DependencyProperty TextColorProperty = DependencyProperty.Register(
            "TextColor", typeof (Brush), typeof (HoverButton), new PropertyMetadata(Brushes.White));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof (string), typeof (HoverButton), new PropertyMetadata(""));

        public static readonly DependencyProperty TextSizeProperty = DependencyProperty.Register(
            "TextSize", typeof (int), typeof (HoverButton), new PropertyMetadata(36));

        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(
            "Image", typeof (string), typeof (HoverButton), new PropertyMetadata(""));

        public int HoverTime
        {
            set { hoverDuration = new Duration(new TimeSpan(0, 0, value)); }
        }

        public Brush BackgroundColor
        {
            get { return (Brush) GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public Brush HoverColor
        {
            get { return (Brush) GetValue(HoverColorProperty); }
            set { SetValue(HoverColorProperty, value); }
        }

        public Brush TextColor
        {
            get { return (Brush) GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public int TextSize
        {
            get { return (int) GetValue(TextSizeProperty); }
            set { SetValue(TextSizeProperty, value); }
        }

        public string Image
        {
            get { return (string) GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        #endregion

        #region Events

        #region Delegates

        public delegate void ClickHandler(object sender, EventArgs e);

        #endregion

        public event ClickHandler Click;

        #endregion

        #region Animation and Event HelperMethods

        private void StartHovering()
        {
            var maxFillHeight = ActualHeight;

            if (!isHovering)
            {
                isHovering = true;
                maskAnimation = new DoubleAnimation(Mask.ActualHeight, maxFillHeight, hoverDuration);
                maskAnimation.Completed += maskAnimation_Completed;
                Mask.BeginAnimation(HeightProperty, maskAnimation);
            }
        }

        private void StopHovering()
        {
            if (isHovering)
            {
                isHovering = false;
                maskAnimation.Completed -= maskAnimation_Completed;
                maskAnimation = new DoubleAnimation(Mask.ActualHeight, 0, reverseDuration);
                Mask.BeginAnimation(HeightProperty, maskAnimation);
            }
        }

        private void maskAnimation_Completed(object sender, EventArgs e)
        {
            isHovering = false;
            if (Click != null)
                Click(this, e);
            Mask.BeginAnimation(HeightProperty, null);
        }

        public bool Check(FrameworkElement cursor)
        {
            if (IsCursorInButton(cursor))
            {
                StartHovering();
                return true;
            }
            else
            {
                StopHovering();
                return false;
            }
        }

        private bool IsCursorInButton(FrameworkElement cursor)
        {
            try
            {
                //Cursor midpoint location
                var cursorTopLeft = cursor.PointToScreen(new Point());
                var cursorCenterX = cursorTopLeft.X + (cursor.ActualWidth/2);
                var cursorCenterY = cursorTopLeft.Y + (cursor.ActualHeight/2);

                //Button location
                var buttonTopLeft = PointToScreen(new Point());
                var buttonLeft = buttonTopLeft.X;
                var buttonRight = buttonLeft + ActualWidth;
                var buttonTop = buttonTopLeft.Y;
                var buttonBottom = buttonTop + ActualHeight;

                if (cursorCenterX < buttonLeft || cursorCenterX > buttonRight)
                    return false;

                if (cursorCenterY < buttonTop || cursorCenterY > buttonBottom)
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        public HoverButton()
        {
            InitializeComponent();
           DataContext = this;
        }
    }
}