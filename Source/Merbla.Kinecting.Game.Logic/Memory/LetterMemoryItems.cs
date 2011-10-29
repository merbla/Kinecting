using System.Collections.Generic;

namespace Merbla.Kinecting.Game.Logic.Memory
{
    public class LetterMemoryItems :List<MemoryItem>
    {
        public LetterMemoryItems()
        {
            Add(new MemoryItem { HiddenText = "T", Text = "?" });
            Add(new MemoryItem { HiddenText = "Z", Text = "?" });
            Add(new MemoryItem { HiddenText = "A", Text = "?" });
            Add(new MemoryItem { HiddenText = "X", Text = "?" });
        } 

    }
}