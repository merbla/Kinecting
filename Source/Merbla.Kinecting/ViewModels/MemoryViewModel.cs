using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Merbla.Kinecting.Events;
using Merbla.Kinecting.Game.Logic.Memory;
using Microsoft.Research.Kinect.Nui;

namespace Merbla.Kinecting.ViewModels
{
    public class MemoryViewModel : KinectingViewModel
    {


        public MemoryViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            var items = new LetterMemoryItems();
            MemoryGame = new MemoryGame(items);

            var x = Tile1.Value.Name;
        }

        public KeyValuePair<int, MemoryItem> Tile1
        {
            get { return MemoryGame.Tiles.ElementAt(0); }
        }

        public KeyValuePair<int, MemoryItem> Tile2
        {
            get { return MemoryGame.Tiles.ElementAt(1); }
        }

        public KeyValuePair<int, MemoryItem> Tile3
        {
            get { return MemoryGame.Tiles.ElementAt(2); }
        }

        public KeyValuePair<int, MemoryItem> Tile4
        {
            get { return MemoryGame.Tiles.ElementAt(3); }
        }

        public KeyValuePair<int, MemoryItem> Tile5
        {
            get { return MemoryGame.Tiles.ElementAt(4); }
        }

        public KeyValuePair<int, MemoryItem> Tile6
        {
            get { return MemoryGame.Tiles.ElementAt(5); }
        }

        public KeyValuePair<int, MemoryItem> Tile7
        {
            get { return MemoryGame.Tiles.ElementAt(6); }
        }
        public KeyValuePair<int, MemoryItem> Tile8
        {
            get { return MemoryGame.Tiles.ElementAt(7); }
        }


        public MemoryGame MemoryGame { get; set; }

        

       
    }
}