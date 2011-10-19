using Caliburn.Micro;
using ReactiveUI;

namespace Merbla.Kinecting.ViewModels
{
    public abstract class KinectingViewModel :Screen //ReactiveValidatedObject
    {


        protected KinectingViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);
        }


        public IEventAggregator EventAggregator { get; set; }

 
    }
}