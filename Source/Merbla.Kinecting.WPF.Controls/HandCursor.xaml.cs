using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Coding4Fun.Kinect.Wpf;
using Microsoft.Research.Kinect.Nui;

namespace Merbla.Kinecting.WPF.Controls
{
    /// <summary>
    ///   Interaction logic for HandCursor.xaml
    /// </summary>
    public partial class HandCursor : UserControl
    {
        //public static readonly DependencyProperty TrackedJointProperty = DependencyProperty.Register("TrackedJoint", typeof (Joint), typeof (HandCursor),
        //    new PropertyMetadata(null));

        public static readonly DependencyProperty TrackedJointProperty = DependencyProperty.Register("TrackedJoint",
                                                                                                     typeof (Joint),
                                                                                                     typeof (HandCursor));


        public HandCursor()
        {
            InitializeComponent();
        }

        public Joint TrackedJoint
        {
            get { return (Joint) GetValue(TrackedJointProperty); }
            set { SetValue(TrackedJointProperty, value); 
            
                SetPosition(TrackedJoint);

#if DEBUG

                var message = string.Format("Hand at X:{0} Y: {1}", TrackedJoint.Position.X, TrackedJoint.Position.Y);
                Debug.WriteLine(message);

#endif

            }
        }

        public void SetPosition(Joint joint)
        {
            var scaledJoint = joint.ScaleTo(800, 600, 0.5f, 0.5f);
            Canvas.SetLeft(this, scaledJoint.Position.X);
            Canvas.SetTop(this, scaledJoint.Position.Y);
        }
    }
}