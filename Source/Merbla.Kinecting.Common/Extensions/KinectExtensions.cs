using System;
using System.Windows;
using Microsoft.Research.Kinect.Nui;

namespace Merbla.Kinecting.Common.Extensions
{
    public static class KinectExtensions
    {
        public static void Initialise(this Runtime nui, Action onSuccess, Action<string> onError)
        {
            nui = new Runtime();

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
    }
}