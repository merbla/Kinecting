using System.Collections.Generic;
using Caliburn.Micro;
using Merbla.Kinecting.Game.Logic.Memory;

namespace Merbla.Kinecting.ViewModels
{
    public class StyledMemoryGameViewModel : MemoryViewModel
    {
        public StyledMemoryGameViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public void Open(KeyValuePair<int, MemoryItem> item)
        {
            
        }
    }
}