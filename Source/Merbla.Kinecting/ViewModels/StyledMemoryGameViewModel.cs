using System.Collections.Generic;
using System.Windows.Controls;
using Caliburn.Micro;
using Coding4Fun.Kinect.Wpf;
using Merbla.Kinecting.Common.Extensions;
using Merbla.Kinecting.Events;
using Merbla.Kinecting.Game.Logic.Memory;
using Microsoft.Research.Kinect.Nui;

namespace Merbla.Kinecting.ViewModels
{
    public class StyledMemoryGameViewModel : MemoryViewModel, IHandle<KinectingEvent<SkeletonFrameReadyEventArgs>>
    {
        public StyledMemoryGameViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public void Close(Button o)
        {
            var item = o.Tag is KeyValuePair<int, MemoryItem>
                        ? (KeyValuePair<int, MemoryItem>) o.Tag
                        : new KeyValuePair<int, MemoryItem>();

            if (item.Key != 0)
                DeselectTile(item.Value.Tile);
        }

        public void Open(KeyValuePair<int, MemoryItem> item)
        {
            SelectTile(item.Value.Tile);
        }

        public void ChooseTile(KeyValuePair<int, MemoryItem> item)
        {
            if(item.Value.Selected)
            {
                //Do nothing
                //DeselectTile(item.Value.Tile);
            }
            else
            {
                SelectTile(item.Value.Tile);
            }
        }

        public void Handle(KinectingEvent<SkeletonFrameReadyEventArgs> message)
        {
            var data = message.MessageObject.SkeletonFrame.GetFirstTrackedSkeleton();
            if (data != null)
            {
                var handJoint = data.Joints[SelectedCursorInteraction];
                TrackedJoint = handJoint;
                var scaledJoint = handJoint.ScaleTo((int)CanvasWidth, (int)CanvasHeight, 0.5f, 0.5f);
                HandCursorX = scaledJoint.Position.X;
                HandCursorY = scaledJoint.Position.Y;
            }
        }
    }
}