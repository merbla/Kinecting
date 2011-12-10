using Caliburn.Micro;
using Microsoft.Research.Kinect.Nui;

namespace Merbla.Kinecting.ViewModels
{
    public abstract class KinectingViewModel : Screen //ReactiveValidatedObject
    {
        private double _canvasHeight;
        private double _canvasWidth;
        private float _handCursorX;
        private float _handCursorY;
        private JointID _selectedCursorInteraction;

        private Joint _trackedJoint;

        protected KinectingViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);

            CanvasHeight = 600;
            CanvasWidth = 800;
            SelectedCursorInteraction = JointID.HandRight;
        }

        public JointID SelectedCursorInteraction
        {
            get { return _selectedCursorInteraction; }
            set
            {
                _selectedCursorInteraction = value;
                NotifyOfPropertyChange(() => SelectedCursorInteraction);
            }
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

        public IEventAggregator EventAggregator { get; set; }
    }
}