#region Using Directives

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

#endregion

namespace Merbla.Kinecting.WPF.Controls
{
    public class ContentControl3D : ContentControl
    {
        #region Fields

        private bool _isRotating;
        private int _rotationRequests;
        private Viewport3D _viewport;

        #endregion // Fields

        #region Constructors

        static ContentControl3D()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof (ContentControl3D),
                new FrameworkPropertyMetadata(typeof (ContentControl3D)));

            AnimationLengthProperty =
                DependencyProperty.Register(
                    "AnimationLength",
                    typeof (int),
                    typeof (ContentControl3D),
                    new UIPropertyMetadata(600, OnAnimationLengthChanged));

            BackContentProperty = DependencyProperty.Register(
                "BackContent",
                typeof (object),
                typeof (ContentControl3D));

            BackContentTemplateProperty = DependencyProperty.Register(
                "BackContentTemplate",
                typeof (DataTemplate),
                typeof (ContentControl3D),
                new UIPropertyMetadata(null));

            IsFrontInViewPropertyKey = DependencyProperty.RegisterReadOnly(
                "IsFrontInView",
                typeof (bool),
                typeof (ContentControl3D),
                new UIPropertyMetadata(true));
            IsFrontInViewProperty = IsFrontInViewPropertyKey.DependencyProperty;
        }

        public ContentControl3D()
        {
            base.CommandBindings.Add(new CommandBinding(RotateCommand, OnRotateCommandExecuted,
                                                        OnCanExecuteRotateCommand));
        }

        #endregion // Constructors

        #region Rotate

        public void Rotate()
        {
            if (_isRotating)
            {
                ++_rotationRequests;
                return;
            }
            else
            {
                _isRotating = true;
            }

            if (_viewport != null)
            {
                // Find front rotation
                var backContentSurface = _viewport.Children[1] as Viewport2DVisual3D;
                var backTransform = backContentSurface.Transform as RotateTransform3D;
                var backRotation = backTransform.Rotation as AxisAngleRotation3D;

                // Find back rotation
                var frontContentSurface = _viewport.Children[2] as Viewport2DVisual3D;
                var frontTransform = frontContentSurface.Transform as RotateTransform3D;
                var frontRotation = frontTransform.Rotation as AxisAngleRotation3D;

                // Create a new camera each time, to avoid trying to animate a frozen instance.
                var camera = CreateCamera();
                _viewport.Camera = camera;

                // Create animations.
                var rotationAnim = new DoubleAnimation
                                       {
                                           Duration = new Duration(TimeSpan.FromMilliseconds(AnimationLength)),
                                           By = 180
                                       };
                var cameraZoomAnim = new Point3DAnimation
                                         {
                                             To = new Point3D(0, 0, 2.5),
                                             Duration = new Duration(TimeSpan.FromMilliseconds(AnimationLength/2)),
                                             AutoReverse = true
                                         };
                cameraZoomAnim.Completed += OnRotationCompleted;

                // Start the animations.
                frontRotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, rotationAnim);
                backRotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, rotationAnim);
                camera.BeginAnimation(ProjectionCamera.PositionProperty, cameraZoomAnim);
            }
        }

        private void OnRotationCompleted(object sender, EventArgs e)
        {
            IsFrontInView = !IsFrontInView;

            _isRotating = false;

            if (_rotationRequests > 0)
            {
                --_rotationRequests;
                Rotate();
            }
        }

        #endregion // Rotate

        #region Rotate Command

        /// <summary>
        ///   Causes the 3D surface to rotate, when executed.
        /// </summary>
        public static readonly RoutedCommand RotateCommand = new RoutedCommand();

        private void OnRotateCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Rotate();
        }

        private void OnCanExecuteRotateCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        #endregion // Rotate Command

        #region Dependency Properties

        #region AnimationLength

        public static readonly DependencyProperty AnimationLengthProperty;

        /// <summary>
        ///   Gets/sets the number of milliseconds it should take to flip the 3D surface over.
        ///   This property cannot be set to a value less than 10.
        /// </summary>
        public int AnimationLength
        {
            get { return (int) GetValue(AnimationLengthProperty); }
            set { SetValue(AnimationLengthProperty, value); }
        }

        private static void OnAnimationLengthChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            var value = (int) e.NewValue;
            if (value < 10)
                throw new ArgumentOutOfRangeException("AnimationLength",
                                                      "AnimationLength cannot be less than 10 milliseconds.");
        }

        #endregion // AnimationLength

        #region BackContent

        public static readonly DependencyProperty BackContentProperty;

        /// <summary>
        ///   Gets/sets the object to display on the back side of the 3D surface.
        /// </summary>
        public object BackContent
        {
            get { return GetValue(BackContentProperty); }
            set { SetValue(BackContentProperty, value); }
        }

        #endregion // BackContent

        #region BackContentTemplate

        public static readonly DependencyProperty BackContentTemplateProperty;

        public DataTemplate BackContentTemplate
        {
            get { return (DataTemplate) GetValue(BackContentTemplateProperty); }
            set { SetValue(BackContentTemplateProperty, value); }
        }

        #endregion // BackContentTemplate

        #region IsFrontInView

        public static readonly DependencyProperty IsFrontInViewProperty;
        private static readonly DependencyPropertyKey IsFrontInViewPropertyKey;

        /// <summary>
        ///   Returns true if the front side of the 3D surface is currently in view.  Read-only.
        /// </summary>
        public bool IsFrontInView
        {
            get { return (bool) GetValue(IsFrontInViewProperty); }
            private set { SetValue(IsFrontInViewPropertyKey, value); }
        }

        #endregion // IsFrontInView

        #endregion // Dependency Properties

        #region Base Class Overrides

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _viewport = Template.FindName("PART_Viewport", this) as Viewport3D;
            if (_viewport != null)
                _viewport.Camera = CreateCamera();
        }

        #endregion // Base Class Overrides

        #region Private Helpers

        private PerspectiveCamera CreateCamera()
        {
            return new PerspectiveCamera
                       {
                           Position = new Point3D(0, 0, 1.2),
                           LookDirection = new Vector3D(0, 0, -1),
                           FieldOfView = 90
                       };
        }

        #endregion // Private Helpers
    }
}