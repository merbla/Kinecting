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
        private MemoryItem _tile1;
        private MemoryItem _tile2;
        private MemoryItem _tile3;
        private MemoryItem _tile4;
        private MemoryItem _tile5;
        private MemoryItem _tile6;
        private MemoryItem _tile7;
        private MemoryItem _tile8;

        public MemoryViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            var items = new LetterMemoryItems();
            MemoryGame = new MemoryGame(items);
           
        }

        public KeyValuePair<int, MemoryItem> Tile1
        {
           get { return MemoryGame.Tiles.Take(1).First(); }
        }

        public MemoryItem Tile2
        {
            get { return _tile2; }
            set
            {
                _tile2 = value;
                NotifyOfPropertyChange(() => Tile2);
            }
        }

        public MemoryItem Tile3
        {
            get { return _tile3; }
            set
            {
                _tile3 = value;
                NotifyOfPropertyChange(() => Tile3);
            }
        }

        public MemoryItem Tile4
        {
            get { return _tile4; }
            set
            {
                _tile4 = value;
                NotifyOfPropertyChange(() => Tile4);
            }
        }

        public MemoryItem Tile5
        {
            get { return _tile5; }
            set
            {
                _tile5 = value;
                NotifyOfPropertyChange(() => Tile5);
            }
        }

        public MemoryItem Tile6
        {
            get { return _tile6; }
            set
            {
                _tile6 = value;
                NotifyOfPropertyChange(() => Tile6);
            }
        }

        public MemoryItem Tile7
        {
            get { return _tile7; }
            set
            {
                _tile7 = value;
                NotifyOfPropertyChange(() => Tile7);
            }
        }

        public MemoryItem Tile8
        {
            get { return _tile8; }
            set
            {
                _tile8 = value;
                NotifyOfPropertyChange(() => Tile8);
            }
        }

        public MemoryGame MemoryGame { get; set; }

        

       
    }
}