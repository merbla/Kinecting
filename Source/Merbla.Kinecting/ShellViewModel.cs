using Merbla.Kinecting.Common.Extensions;
using Merbla.Kinecting.ViewModels;
using Microsoft.Research.Kinect.Nui;
using ReactiveUI;

namespace Merbla.Kinecting
{
    public class ShellViewModel : KinectingViewModel, IShell
    {
        private Runtime _nui;

        private string _StatusText;

        public ShellViewModel()
        {
            _nui.Initialise(() =>
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