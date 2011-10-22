using System;

namespace Merbla.Kinecting.Game.Logic.Memory
{
    public class MemoryItem
    {
        public MemoryItem()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        
    }
}