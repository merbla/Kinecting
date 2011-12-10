using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Research.Kinect.Nui;

namespace Merbla.Kinecting.Common.Extensions
{
    public static class KinectExtensions
    {
        public static void Initialise(this Runtime nui, Action onSuccess, Action<string> onError)
        {

            try
            {
                nui.Initialize(RuntimeOptions.UseDepthAndPlayerIndex | RuntimeOptions.UseSkeletalTracking | RuntimeOptions.UseColor);
            }
            catch (InvalidOperationException)
            {
                onError.Invoke("Runtime initialization failed. Please make sure Kinect device is plugged in.");
                return;
            }
            
            try
            { 
                nui.VideoStream.Open(ImageStreamType.Video, 2, ImageResolution.Resolution640x480, ImageType.Color);
                nui.DepthStream.Open(ImageStreamType.Depth, 2, ImageResolution.Resolution320x240, ImageType.DepthAndPlayerIndex);
            }
            catch (InvalidOperationException)
            {
                onError.Invoke("Failed to open stream. Please make sure to specify a supported image type and resolution.");
                return;
            }

            onSuccess.Invoke();
        }

        public static void Test(this Runtime nui)
        {
            var skeletonFrameReadyObservable = Observable.FromEventPattern(nui, "SkeletonFrameReady");

            var trackedSkeletons = from ev in skeletonFrameReadyObservable.Cast<EventPattern<SkeletonFrameReadyEventArgs>>()
                                   from skel in ev.EventArgs.SkeletonFrame.Skeletons
                                   where skel.TrackingState == SkeletonTrackingState.Tracked
                                   select skel;

            //var rightHandPositions = trackedSkeletons.ObserveOnDispatcher()
            //    .Select(s => s.Joints[JointID.HandRight]);

            //var lefttHandPositions = trackedSkeletons.ObserveOnDispatcher()
            //    .Select(s => s.Joints[JointID.HandLeft]);
        }



        public static WriteableBitmap CreateLivePlayerRenderer(this Runtime runtime)
        {
            if (runtime.DepthStream.Width == 0)
                throw new InvalidOperationException("Either open the depth stream before calling this method or use the overload which takes in the resolution that the depth stream will later be opened with.");
            return runtime.CreateLivePlayerRenderer(runtime.DepthStream.Width, runtime.DepthStream.Height);
        }

        public static WriteableBitmap CreateLivePlayerRenderer(this Runtime runtime, int depthWidth, int depthHeight)
        {
            PlanarImage depthImage = new PlanarImage();
            WriteableBitmap target = new WriteableBitmap(depthWidth, depthHeight, 96, 96, PixelFormats.Bgra32, null);
            var depthRect = new System.Windows.Int32Rect(0, 0, depthWidth, depthHeight);

            runtime.DepthFrameReady += (s, e) =>
            {
                depthImage = e.ImageFrame.Image;
                Debug.Assert(depthImage.Height == depthHeight && depthImage.Width == depthWidth);
            };
            runtime.VideoFrameReady += (s, e) =>
            {
                // don't do anything if we don't yet have a depth image
                if (depthImage.Bits == null)
                    return;

                byte[] color = e.ImageFrame.Image.Bits;
                byte[] output = new byte[depthWidth * depthHeight * 4];

                // loop over each pixel in the depth image
                int outputIndex = 0;
                for (int depthY = 0, depthIndex = 0; depthY < depthHeight; depthY++)
                {
                    for (int depthX = 0; depthX < depthWidth; depthX++, depthIndex += 2)
                    {
                        // combine the 2 bytes of depth data representing this pixel
                        short depthValue = (short)(depthImage.Bits[depthIndex] | (depthImage.Bits[depthIndex + 1] << 8));

                        // extract the id of a tracked player from the first bit of depth data for this pixel
                        int player = depthImage.Bits[depthIndex] & 7;

                        // find a pixel in the color image which matches this coordinate from the depth image
                        int colorX, colorY;
                        runtime.NuiCamera.GetColorPixelCoordinatesFromDepthPixel(
                                                    e.ImageFrame.Resolution,
                                                    e.ImageFrame.ViewArea,
                                                    depthX, depthY, // depth coordinate
                                                    depthValue,  // depth value
                                                    out colorX, out colorY);  // color coordinate                        

                        // ensure that the calculated color location is within the bounds of the image
                        colorX = Math.Max(0, Math.Min(colorX, e.ImageFrame.Image.Width - 1));
                        colorY = Math.Max(0, Math.Min(colorY, e.ImageFrame.Image.Height - 1));
                        output[outputIndex++] = color[(4 * (colorX + (colorY * e.ImageFrame.Image.Width))) + 0];
                        output[outputIndex++] = color[(4 * (colorX + (colorY * e.ImageFrame.Image.Width))) + 1];
                        output[outputIndex++] = color[(4 * (colorX + (colorY * e.ImageFrame.Image.Width))) + 2];
                        output[outputIndex++] = player > 0 ? (byte)255 : (byte)0;
                    }
                }
                target.WritePixels(depthRect, output, depthWidth * PixelFormats.Bgra32.BitsPerPixel / 8, 0);
            };
            return target;
        }

        public static void SetSmoothTransform(this Runtime runtime)
        {
            runtime.SkeletonEngine.TransformSmooth = true;

            var parameters = new TransformSmoothParameters
            {
                Smoothing = 0.75f,
                Correction = 0.0f,
                Prediction = 0.0f,
                JitterRadius = 0.05f,
                MaxDeviationRadius = 0.04f
            };

            runtime.SkeletonEngine.SmoothParameters = parameters;
        }

        public static SkeletonData GetFirstTrackedSkeleton(this SkeletonFrame skeletonSet)
        {
            SkeletonData data = (from s in skeletonSet.Skeletons
                                 where s.TrackingState == SkeletonTrackingState.Tracked
                                 select s).FirstOrDefault();
            return data;
        }
    }
}