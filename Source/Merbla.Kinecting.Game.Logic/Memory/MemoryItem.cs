using System;

namespace Merbla.Kinecting.Game.Logic.Memory
{
    public class MemoryItem
    {
        public MemoryItem()
        {
            Id = Guid.NewGuid();
            Selected = false;
            Matched = false;
        }

        public Guid Id { get; set; }

        public string HiddenText { get; set; }
         
        public bool Selected { get; set; }

        public bool Matched { get; set; }

        public string Text { get; set; }
    }
}