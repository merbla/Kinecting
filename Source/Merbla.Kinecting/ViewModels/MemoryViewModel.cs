using Caliburn.Micro;
using Merbla.Kinecting.Game.Logic.Memory;

namespace Merbla.Kinecting.ViewModels
{
    public class MemoryViewModel : KinectingViewModel
    {
        private MemoryGame _memoryGame;


        public MemoryViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            var items = new LetterMemoryItems();
            MemoryGame = new MemoryGame(items);
        }
        
        public MemoryGame MemoryGame
        {
            get { return _memoryGame; }
            set
            {
                _memoryGame = value;
                NotifyChanges();
            }
        }

        public void CloseTile1()
        {
            MemoryGame.UnselectTile(Tile.One);
            NotifyChanges();
        }

        public void OpenTile1()
        {
            MemoryGame.SelectTile(Tile.One);
            NotifyChanges();
        }

        public void CloseTile3()
        {
            MemoryGame.UnselectTile(Tile.Three);
            NotifyChanges();
        }

        public void OpenTile3()
        {
            MemoryGame.SelectTile(Tile.Three);
            NotifyChanges();
        }

        public void CloseTile2()
        {
            MemoryGame.UnselectTile(Tile.Two);
            NotifyChanges();
        }

        public void OpenTile2()
        {
            MemoryGame.SelectTile(Tile.Two);
            NotifyChanges();
        }

        public void CloseTile4()
        {
            MemoryGame.UnselectTile(Tile.Four);
            NotifyChanges();
        }

        public void OpenTile4()
        {
            MemoryGame.SelectTile(Tile.Four);
            NotifyChanges();
        }

        public void CloseTile5()
        {
            MemoryGame.UnselectTile(Tile.Five);
            NotifyChanges();
        }

        public void OpenTile5()
        {
            MemoryGame.SelectTile(Tile.Five);
            NotifyChanges();
        }

        public void CloseTile8()
        {
            MemoryGame.UnselectTile(Tile.Eight);
            NotifyChanges();
        }

        public void OpenTile8()
        {
            MemoryGame.SelectTile(Tile.Eight);
            NotifyChanges();
        }

        public void CloseTile6()
        {
            MemoryGame.UnselectTile(Tile.Six);
            NotifyChanges();
        }

        public void OpenTile6()
        {
            MemoryGame.SelectTile(Tile.Six);
            NotifyChanges();
        }

        public void CloseTile7()
        {
            MemoryGame.UnselectTile(Tile.Seven);
            NotifyChanges();
        }

        public void OpenTile7()
        {
            MemoryGame.SelectTile(Tile.Seven);
            NotifyChanges();
        }

        private void NotifyChanges()
        {
            NotifyOfPropertyChange(() => MemoryGame);
            NotifyOfPropertyChange(() => CanOpenTile1);
            NotifyOfPropertyChange(() => CanOpenTile2);
            NotifyOfPropertyChange(() => CanOpenTile3);
            NotifyOfPropertyChange(() => CanOpenTile4);
            NotifyOfPropertyChange(() => CanOpenTile5);
            NotifyOfPropertyChange(() => CanOpenTile6);
            NotifyOfPropertyChange(() => CanOpenTile7);
            NotifyOfPropertyChange(() => CanOpenTile8);
        }

        public bool CanOpenTile1
        {
            get { return !MemoryGame.Tile1.Value.Matched; }
        }

        public bool CanOpenTile2
        {
            get { return !MemoryGame.Tile2.Value.Matched; }
        }

        public bool CanOpenTile3
        {
            get { return !MemoryGame.Tile3.Value.Matched; }
        }

        public bool CanOpenTile4
        {
            get { return !MemoryGame.Tile4.Value.Matched; }
        }

        public bool CanOpenTile5
        {
            get { return !MemoryGame.Tile5.Value.Matched; }
        }

        public bool CanOpenTile6
        {
            get { return !MemoryGame.Tile6.Value.Matched; }
        }

        public bool CanOpenTile7
        {
            get { return !MemoryGame.Tile7.Value.Matched; }
        }

        public bool CanOpenTile8
        {
            get { return !MemoryGame.Tile8.Value.Matched; }
        }



    }
}