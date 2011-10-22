using System.Collections.Generic;

namespace Merbla.Kinecting.Game.Logic.Memory
{
    public class LetterMemoryItems :List<MemoryItem>
    {
        public LetterMemoryItems()
        {
            Add(new MemoryItem {Name = "T"});
            Add(new MemoryItem { Name = "Z" });
            Add(new MemoryItem { Name = "A" });
            Add(new MemoryItem { Name = "X" });
        } 

    }
}