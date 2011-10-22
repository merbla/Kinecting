using Caliburn.Micro;
using Merbla.Kinecting.Events;
using Microsoft.Research.Kinect.Nui;

namespace Merbla.Kinecting.ViewModels
{
    public class MemoryViewModel : KinectingViewModel, IHandle<KinectingEvent<SkeletonFrameReadyEventArgs>>
    {
        public MemoryViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public void Handle(KinectingEvent<SkeletonFrameReadyEventArgs> message)
        {
            

        }
    }
}