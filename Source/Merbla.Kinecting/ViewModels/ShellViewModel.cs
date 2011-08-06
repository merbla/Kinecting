using System;
using Caliburn.Micro;
using Merbla.Kinecting.Common.Extensions;
using Merbla.Kinecting.Events;
using Merbla.Kinecting.Views;
using Microsoft.Research.Kinect.Nui;
using ReactiveUI;

namespace Merbla.Kinecting.ViewModels
{
    public class ShellViewModel : KinectingViewModel, IShell
    {
        private string _StatusText;
        private readonly Runtime _kinectRuntime;

        public ShellViewModel(IWindowManager windowManager, IEventAggregator eventAggregator, Runtime kinectRuntime) : base(windowManager, eventAggregator)
        {
            _kinectRuntime = kinectRuntime;
            Initialise();
        }

        private void Initialise()
        {
            _kinectRuntime.Initialise(() =>
                                          {
                                              //Wire Up Events
                                              _kinectRuntime.VideoFrameReady +=
                                                  (o, args) => EventAggregator.Publish(new KinectingEvent<ImageFrameReadyEventArgs>(args));

                                              _kinectRuntime.SkeletonFrameReady +=
                                                  (o, args) => EventAggregator.Publish(new KinectingEvent<SkeletonFrameReadyEventArgs>(args));

                                              _kinectRuntime.DepthFrameReady +=
                                                  (o, args) => EventAggregator.Publish(new KinectingEvent<ImageFrameReadyEventArgs>(args));
                                          },

                                      (e) =>
                                          {
                                              //Show Error
                                              StatusText = e;
                                          });
        }


        public string StatusText
        {
            get { return _StatusText; }
            set { this.RaiseAndSetIfChanged(x => x.StatusText, value); }
        }
    }
}