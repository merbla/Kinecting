using Merbla.Kinecting.Common.Extensions;
using Merbla.Kinecting.ViewModels;
using Microsoft.Research.Kinect.Nui;
using ReactiveUI;

namespace Merbla.Kinecting
{
    public class ShellViewModel : KinectingViewModel, IShell
    {
        private string _StatusText;
        private Runtime _kinectRuntime;

        public ShellViewModel()
        {

            //TODO: Add IoC
            _kinectRuntime.Initialise(() =>
                                {
                                    //Wire Up Events
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