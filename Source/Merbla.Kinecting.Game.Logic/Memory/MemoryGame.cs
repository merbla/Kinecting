using System;
using System.Collections.Generic;
using System.Linq;

namespace Merbla.Kinecting.Game.Logic.Memory
{

    public class MemoryGame
    {
        public void SelectTile(Tile tile)
        {
            SelectTile(tile, true);
            DetermineIfMatch(tile);
        }

        private bool DetermineIfMatch(Tile tile)
        {

            //Tiles.Where(x=>x.Value.Selected && x.Value.)
            return false;

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

            Initalise();
        }

        public KeyValuePair<int, MemoryItem> Tile1
        {
            get { return Tiles.First(x => x.Value.Tile == Tile.One); }
        }

        public KeyValuePair<int, MemoryItem> Tile2
        {
            get { return Tiles.First(x => x.Value.Tile == Tile.Two); }
        }

        public KeyValuePair<int, MemoryItem> Tile3
        {
            get { return Tiles.First(x => x.Value.Tile == Tile.Three); }
        }

        public KeyValuePair<int, MemoryItem> Tile4
        {
            get { return Tiles.First(x => x.Value.Tile == Tile.Four); }
        }

        public KeyValuePair<int, MemoryItem> Tile5
        {
            get { return Tiles.First(x => x.Value.Tile == Tile.Five); }
        }

        public KeyValuePair<int, MemoryItem> Tile6
        {
            get { return Tiles.First(x => x.Value.Tile == Tile.Six); }
        }

        public KeyValuePair<int, MemoryItem> Tile7
        {
            get { return Tiles.First(x => x.Value.Tile == Tile.Seven); }
        }

        public KeyValuePair<int, MemoryItem> Tile8
        {
            get { return Tiles.First(x => x.Value.Tile == Tile.Eight); }
        }


        public IList<MemoryItem> Items { get; private set; }
        public Dictionary<int, MemoryItem> Tiles { get; private set; }

        private void Initalise()
        {
            Tiles = new Dictionary<int, MemoryItem>();

            var r = new Random();

            while (Tiles.Count != 8)
            {
                var nextValue = r.Next(1, 9);

                if (!Tiles.ContainsKey(nextValue))
                {
                    var element = r.Next(0, 4);

                    var memoryItem = Items.ElementAt(element);

                    if (Tiles.Count(x => x.Value.Id == memoryItem.Id) != 2)
                    {
                        var item = (MemoryItem)memoryItem.Clone(); 
                        item.TileNumber = nextValue;
                        Tiles.Add(item.TileNumber, item);
                    }
                }
            }
        }
    }
} 