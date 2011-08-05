using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Research.Kinect.Nui;

namespace Merbla.Kinecting.Common
{
    public class SkeletonHelper
    {
        public static Polyline GetBodySegment(Runtime nui, JointsCollection joints, Brush brush,
                                              IEnumerable<JointID> jointIds, int width, int height)
        {
            var points = new PointCollection();

            foreach (var id in jointIds)
            {
                points.Add(GetDisplayPosition(nui, joints[id], width, height));
            }

            var polyline = new Polyline {Points = points, Stroke = brush, StrokeThickness = 5};
            return polyline;
        }

        private static Point GetDisplayPosition(Runtime nui, Joint joint, int width, int height)
        {
            float depthX, depthY;
            nui.SkeletonEngine.SkeletonToDepthImage(joint.Position, out depthX, out depthY);
            depthX = depthX*320; //convert to 320, 240 space
            depthY = depthY*240; //convert to 320, 240 space
            int colorX, colorY;
            var iv = new ImageViewArea();
            // only ImageResolution.Resolution640x480 is supported at this point
            nui.NuiCamera.GetColorPixelCoordinatesFromDepthPixel(ImageResolution.Resolution640x480, iv, (int) depthX,
                                                                 (int) depthY, 0, out colorX, out colorY);

            // map back to skeleton.Width & skeleton.Height
            return new Point((int) (width*colorX/640.0), (height*colorY/480));
        }
    }
}