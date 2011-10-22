using System;
using System.Collections.Generic;
using System.Linq;

namespace Merbla.Kinecting.Game.Logic.Memory
{
    public class MemoryGame
    {
        public MemoryGame(IList<MemoryItem> items)
        {
            Items = items;
            Tiles = new Dictionary<int, MemoryItem>();
            Initalise();
        }

        public IList<MemoryItem> Items { get; private set; }
        public Dictionary<int, MemoryItem> Tiles { get; private set; }

        private void Initalise()
        {
            var r = new Random();

            while (Tiles.Count != 8)
            {
                var nextValue = r.Next(8);
                if (!Tiles.ContainsKey(nextValue))
                {
                    var memoryItem = Items.OrderBy(x => r.Next()).Take(1).First();
                    if(Tiles.Count(x=> x.Value.Id == memoryItem.Id) != 2)
                        Tiles.Add(nextValue, memoryItem);
                }
            }
        }
    }
}