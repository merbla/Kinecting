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
        private double _canvasHeight;
        private double _canvasWidth;
        private float _handCursorX;
        private float _handCursorY;

        private Joint _trackedJoint;

        public ShellViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
            _eventAggregator.Subscribe(this);

            CanvasHeight = 600;
            CanvasWidth = 800;
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

        public double CanvasHeight
        {
            get { return _canvasHeight; }
            set
            {
                _canvasHeight = value;
                NotifyOfPropertyChange(() => CanvasHeight);
            }
        }

        public double CanvasWidth
        {
            get { return _canvasWidth; }
            set
            {
                _canvasWidth = value;
                NotifyOfPropertyChange(() => CanvasWidth);
            }
        }


        public float HandCursorX
        {
            get { return _handCursorX; }
            set
            {
                _handCursorX = value;
                NotifyOfPropertyChange(() => HandCursorX);
            }
        }

        public float HandCursorY
        {
            get { return _handCursorY; }
            set
            {
                _handCursorY = value;

                NotifyOfPropertyChange(() => HandCursorY);
            }
        }

        #region IHandle<KinectingEvent<SkeletonFrameReadyEventArgs>> Members

        public void Handle(KinectingEvent<SkeletonFrameReadyEventArgs> message)
        {
            var data = message.MessageObject.SkeletonFrame.GetFirstTrackedSkeleton();

            if (data != null)
            {
                var handJoint = data.Joints[JointID.HandRight];

                TrackedJoint = handJoint;
                var scaledJoint = handJoint.ScaleTo((int) CanvasWidth, (int) CanvasHeight, 0.5f, 0.5f);
                HandCursorX = scaledJoint.Position.X;
                HandCursorY = scaledJoint.Position.Y;

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