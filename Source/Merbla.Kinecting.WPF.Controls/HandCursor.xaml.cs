using System.Windows.Controls;
using Coding4Fun.Kinect.Wpf;
using Microsoft.Research.Kinect.Nui;

namespace Merbla.Kinecting.WPF.Controls
{
    /// <summary>
    /// Interaction logic for HandCursor.xaml
    /// </summary>
    public partial class HandCursor : UserControl
    {
        public HandCursor()
        {
            InitializeComponent();
        }

        public void SetPosition(Joint joint)
        {
            Joint scaledJoint = joint.ScaleTo(800, 600, 0.5f, 0.5f);
            Canvas.SetLeft(this, scaledJoint.Position.X);
            Canvas.SetTop(this, scaledJoint.Position.Y);
        }
    }
}
