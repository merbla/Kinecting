using Caliburn.Micro;
using ReactiveUI;

namespace Merbla.Kinecting.ViewModels
{
    public abstract class KinectingViewModel : ReactiveValidatedObject
    {
        public IWindowManager WindowManager { get; set; }
        public IEventAggregator EventAggregator { get; set; }


        protected KinectingViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            WindowManager = windowManager;
            EventAggregator = eventAggregator;

        }
    }
}