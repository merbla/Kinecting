using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;

namespace Merbla.Kinecting.Game.Logic.Memory
{
    public class MemoryGame : PropertyChangedBase
    {
        public MemoryGame(IEnumerable<MemoryItem> items)
        {
            //TODO: Remove Caliburn and move to AOP for INotifyPropertyChanged
            Items = new BindableCollection<MemoryItem>(items);
            Initalise();
        }

        public int TilesSelected
        {
            get { return Tiles.Count(x => x.Value.Selected); }
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

        private BindableCollection<MemoryItem> _items;
        public BindableCollection<MemoryItem> Items
        {
            get { return _items; }
            private set { _items = value; NotifyOfPropertyChange(()=> Items); }
        }

        private Dictionary<int, MemoryItem> _tiles;
        public Dictionary<int, MemoryItem> Tiles
        {
            get { return _tiles; }
            private set { _tiles = value; NotifyOfPropertyChange(()=> Tiles); }
        }

        public bool SelectTile(Tile tile)
        {
            SelectTile(tile, true);
            return DetermineIfMatch(tile);
        }

        private bool DetermineIfMatch(Tile tile)
        {
            var selectedTile = Tiles.First(x => x.Value.Tile == tile);
            bool matched = Tiles.Count(x => x.Value.Id == selectedTile.Value.Id && x.Value.Selected) == 2;
            if(matched)
            {

                selectedTile.Value.Matched = true;
   
            }

            return matched;

        }

        public void DeselectTile(Tile tile)
        {
            SelectTile(tile, false);
        }

        public void ResetTiles()
        {
            foreach (var memoryItem in Tiles)
            {
                SelectTile(memoryItem.Value.Tile, false);
            }
        }

        public void ShowAll()
        {
            foreach (var memoryItem in Tiles)
            {
                SelectTile(memoryItem.Value.Tile, true);
            }  
        }


        private void SelectTile(Tile tile, bool selected)
        {
            //TODO: Validate only two selected tiles are allowed??
            Tiles.First(x => x.Value.Tile == tile).Value.Selected = selected;
        }

        private void Initalise()
        {
            Tiles = new Dictionary<int, MemoryItem>();

            var rand = new Random();

            while (Tiles.Count != 8)
            {
                var nextValue = rand.Next(1, 9);

                if (!Tiles.ContainsKey(nextValue))
                {
                    var element = rand.Next(0, 4);

                    var memoryItem = Items.ElementAt(element);

                    if (Tiles.Count(x => x.Value.Id == memoryItem.Id) != 2)
                    {
                        var item = (MemoryItem) memoryItem.Clone();
                        item.TileNumber = nextValue;
                        Tiles.Add(item.TileNumber, item);
                    }
                }
            }
        }
    }
}