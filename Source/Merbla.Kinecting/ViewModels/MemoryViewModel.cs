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
                NotifyOfPropertyChange(() => MemoryGame);
            }
        }


        public void CloseTile1()
        {
            MemoryGame.UnselectTile(Tile.One);
            NotifyOfPropertyChange(() => MemoryGame);
        }

        public void OpenTile1()
        {
            MemoryGame.SelectTile(Tile.One);
            NotifyOfPropertyChange(() => MemoryGame);
        }


        public void CloseTile3()
        {
            MemoryGame.UnselectTile(Tile.Three);
            NotifyOfPropertyChange(() => MemoryGame);
        }

        public void OpenTile3()
        {
            MemoryGame.SelectTile(Tile.Three);
            NotifyOfPropertyChange(() => MemoryGame);
        }


        public void CloseTile2()
        {
            MemoryGame.UnselectTile(Tile.Two);
            NotifyOfPropertyChange(() => MemoryGame);
        }

        public void OpenTile2()
        {
            MemoryGame.SelectTile(Tile.Two);
            NotifyOfPropertyChange(() => MemoryGame);
        }


        public void CloseTile4()
        {
            MemoryGame.UnselectTile(Tile.Four);
            NotifyOfPropertyChange(() => MemoryGame);
        }

        public void OpenTile4()
        {
            MemoryGame.SelectTile(Tile.Four);
            NotifyOfPropertyChange(() => MemoryGame);
        }


        public void CloseTile5()
        {
            MemoryGame.UnselectTile(Tile.Five);
            NotifyOfPropertyChange(() => MemoryGame);
        }

        public void OpenTile5()
        {
            MemoryGame.SelectTile(Tile.Five);
            NotifyOfPropertyChange(() => MemoryGame);
        }


        public void CloseTile8()
        {
            MemoryGame.UnselectTile(Tile.Eight);
            NotifyOfPropertyChange(() => MemoryGame);
        }

        public void OpenTile8()
        {
            MemoryGame.SelectTile(Tile.Eight);
            NotifyOfPropertyChange(() => MemoryGame);
        }


        public void CloseTile6()
        {
            MemoryGame.UnselectTile(Tile.Six);
            NotifyOfPropertyChange(() => MemoryGame);
        }

        public void OpenTile6()
        {
            MemoryGame.SelectTile(Tile.Six);
            NotifyOfPropertyChange(() => MemoryGame);
        }


        public void CloseTile7()
        {
            MemoryGame.UnselectTile(Tile.Seven);
            NotifyOfPropertyChange(() => MemoryGame);
        }

        public void OpenTile7()
        {
            MemoryGame.SelectTile(Tile.Seven);
            NotifyOfPropertyChange(() => MemoryGame);
            ;
        }
    }
}