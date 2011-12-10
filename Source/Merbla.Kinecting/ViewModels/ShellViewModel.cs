using Caliburn.Micro;
using Coding4Fun.Kinect.Wpf;
using Merbla.Kinecting.Common.Extensions;
using Merbla.Kinecting.Events;
using Microsoft.Research.Kinect.Nui;

namespace Merbla.Kinecting.ViewModels
{
    public class ShellViewModel : Conductor<KinectingViewModel>, IHandle<KinectingEvent<SkeletonFrameReadyEventArgs>>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IWindowManager _windowManager;

        private Joint _trackedJoint;

        public ShellViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
            _eventAggregator.Subscribe(this);
        }

        public Joint TrackedJoint
        {
            get { return _trackedJoint; }
            set
            {
                _trackedJoint = value;
                NotifyOfPropertyChange(() => TrackedJoint);
            }
        }

        private float _handCursorX;
        public float HandCursorX
        {
            get { return _handCursorX; }
            set { _handCursorX = value; NotifyOfPropertyChange(()=> HandCursorX); }
        }

        private float _handCursorY;
        public float HandCursorY
        {
            get { return _handCursorY; }
            set { _handCursorY = value; 
            
            NotifyOfPropertyChange(()=> HandCursorY);}
        }

        #region IHandle<KinectingEvent<SkeletonFrameReadyEventArgs>> Members

        public void Handle(KinectingEvent<SkeletonFrameReadyEventArgs> message)
        {
            var data = message.MessageObject.SkeletonFrame.GetFirstTrackedSkeleton();

            if (data != null)
            {
                var handJoint = data.Joints[JointID.Head];

                TrackedJoint = handJoint;
                 var scaledJoint = handJoint.ScaleTo(800, 600, 0.5f, 0.5f); 
                
                //scaledJoint.Posito
                
                
                    //Canvas.SetTop(this, scaledJoint.Position.Y);

                //hand.SetPosition(handJoint);
                //btn1.Check(hand);
            }
        }

        #endregion

        protected override void OnActivate()
        {
            base.OnActivate();
            ActivateItem(IoC.Get<StyledMemoryGameViewModel>());
        }
    }
}