using System.Collections.Generic;
using System.Windows.Controls;
using Caliburn.Micro;
using Merbla.Kinecting.Game.Logic.Memory;

namespace Merbla.Kinecting.ViewModels
{
    public class StyledMemoryGameViewModel : MemoryViewModel
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
                DeselectTile(item.Value.Tile);
            }
            else
            {
                SelectTile(item.Value.Tile);
            }
        }
    }
}