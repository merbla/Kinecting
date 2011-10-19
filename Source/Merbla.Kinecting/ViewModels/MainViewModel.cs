using System;
using System.Linq;
using Caliburn.Micro;
using Merbla.Kinecting.Events;
using Microsoft.Research.Kinect.Nui;

namespace Merbla.Kinecting.ViewModels
{
    public class MainViewModel : KinectingViewModel, IHandle<KinectingEvent<SkeletonFrameReadyEventArgs>>
    {
        private readonly Runtime _kinectRuntime;
        private BindableCollection<string> _skeletonItems;
        private string _statusText;

        public MainViewModel(IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            SkeletonItems = new BindableCollection<string>();
        }

        public BindableCollection<String> SkeletonItems
        {
            get { return _skeletonItems; }
            set
            {
                _skeletonItems = value;
                NotifyOfPropertyChange(() => SkeletonItems);
            }
        }

        public string StatusText
        {
            get { return _statusText; }
            set
            {
                _statusText = value;
                NotifyOfPropertyChange(() => StatusText);
            }
        }

        #region IHandle<KinectingEvent<SkeletonFrameReadyEventArgs>> Members

        public void Handle(KinectingEvent<SkeletonFrameReadyEventArgs> message)
        {
            var trackedSkeletons =
                message.MessageObject.SkeletonFrame.Skeletons
                    .Where(x => x.TrackingState == SkeletonTrackingState.Tracked);

            var lefthand = trackedSkeletons.Select(x => x.Joints[JointID.HandLeft])
                .Select(s => new
                                 {
                                     Text =
                                 "Location of Left Hand - X:" + s.Position.X +
                                 " Y:" + s.Position.Y 

                                 });


            var righthand = trackedSkeletons.Select(x => x.Joints[JointID.HandRight])
                .Select(s => new
                                 {
                                     Text =
                                 "Location of Right Hand - X:" + s.Position.X +
                                 " Y:" + s.Position.Y 
                                 });


            foreach (var l in lefthand)
            {
                StatusText = StatusText + l.Text;
                SkeletonItems.Add(l.Text);
            }

            foreach (var l in righthand)
            {
                StatusText = StatusText + l.Text;
                SkeletonItems.Add(l.Text);
            }
        }

        #endregion
    }
}