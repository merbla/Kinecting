using System;
using System.Collections.Generic;
using System.Linq;

namespace Merbla.Kinecting.Game.Logic.Memory
{
    public enum Tile
    {
        One, Two, Three, Four, Five, Six, Seven, Eight
    }

    public class MemoryGame
    {


        

        public void SelectTile(Tile tile)
        {
            SelectTile(tile, true);
        }

        public void UnselectTile(Tile tile)
        {
            SelectTile(tile, false);
        }

        private void SelectTile(Tile tile, bool selected)
        {
            //TODO: Validate only two selected tiles are allowed??


            switch (tile)
            {
                case Tile.One:
                    Tile1.Value.Selected = selected;
                    break;
                case Tile.Two:
                    Tile2.Value.Selected = selected;
                    break;
                case Tile.Three:
                    Tile3.Value.Selected = selected;
                    break;
                case Tile.Four:
                    Tile4.Value.Selected = selected;
                    break;
                case Tile.Five:
                    Tile5.Value.Selected = selected;
                    break;
                case Tile.Six:
                    Tile6.Value.Selected = selected;
                    break;
                case Tile.Seven:
                    Tile7.Value.Selected = selected;
                    break;
                case Tile.Eight:
                    Tile8.Value.Selected = selected;
                    break;
                default:
                    break;
            }
        }


        public MemoryGame(IList<MemoryItem> items)
        {
            Items = items;
            Tiles = new Dictionary<int, MemoryItem>();
            Initalise();
        }

        public KeyValuePair<int, MemoryItem> Tile1
        {
            get { return Tiles.ElementAt(0); }
        }

        public KeyValuePair<int, MemoryItem> Tile2
        {
            get { return Tiles.ElementAt(1); }
        }

        public KeyValuePair<int, MemoryItem> Tile3
        {
            get { return Tiles.ElementAt(2); }
        }

        public KeyValuePair<int, MemoryItem> Tile4
        {
            get { return Tiles.ElementAt(3); }
        }

        public KeyValuePair<int, MemoryItem> Tile5
        {
            get { return Tiles.ElementAt(4); }
        }

        public KeyValuePair<int, MemoryItem> Tile6
        {
            get { return Tiles.ElementAt(5); }
        }

        public KeyValuePair<int, MemoryItem> Tile7
        {
            get { return Tiles.ElementAt(6); }
        }

        public KeyValuePair<int, MemoryItem> Tile8
        {
            get { return Tiles.ElementAt(7); }
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