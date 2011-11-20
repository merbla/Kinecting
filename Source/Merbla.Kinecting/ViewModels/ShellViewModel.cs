using Caliburn.Micro;
using Merbla.Kinecting.Common.Extensions;
using Merbla.Kinecting.Events;
using Merbla.Kinecting.Views;
using Microsoft.Research.Kinect.Nui;
using ReactiveUI;

namespace Merbla.Kinecting.ViewModels
{
    public class ShellViewModel : Conductor<KinectingViewModel>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IWindowManager _windowManager;

        public ShellViewModel( IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
        }
        protected override void OnActivate()
        {
            base.OnActivate();
            //ActivateItem(IoC.Get<MainViewModel>());

            //ActivateItem(IoC.Get<MemoryViewModel>());
            ActivateItem(IoC.Get<StyledMemoryGameViewModel>());

        }
    }
}