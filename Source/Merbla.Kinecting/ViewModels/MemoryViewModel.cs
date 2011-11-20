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
         
            DeselectTile(Tile.One); 
        }

        public void OpenTile1()
        {
            SelectTile(Tile.One);
        }




        public void CloseTile3()
        {
            DeselectTile(Tile.Three);
        }

        public void OpenTile3()
        {
            SelectTile(Tile.Three);
        }

        public void CloseTile2()
        {
            DeselectTile(Tile.Two);
        }

        public void OpenTile2()
        {
            SelectTile(Tile.Two);
        }

        public void CloseTile4()
        {
            DeselectTile(Tile.Four);
        }

        public void OpenTile4()
        {
            SelectTile(Tile.Four);
        }

        public void CloseTile5()
        {
            DeselectTile(Tile.Five);
        }

        public void OpenTile5()
        {
            SelectTile(Tile.Five);
        }

        public void CloseTile8()
        {
            DeselectTile(Tile.Eight);
        }

        public void OpenTile8()
        {
            SelectTile(Tile.Eight);
        }

        public void CloseTile6()
        {
            DeselectTile(Tile.Six);
        }

        public void OpenTile6()
        {
            SelectTile(Tile.Six);
        }

        public void CloseTile7()
        {
            DeselectTile(Tile.Seven);
        }

        public void OpenTile7()
        {
            SelectTile(Tile.Seven);
        }

        private void DeselectTile(Tile selectedTile)
        {
            MemoryGame.DeselectTile(selectedTile);
            NotifyChanges();
        }

        public void ShowAll()
        {
           // MemoryGame.ShowAll();
            SelectTile(Tile.One);
            SelectTile(Tile.Two);
            SelectTile(Tile.Three);
            SelectTile(Tile.Four);
            SelectTile(Tile.Five);
            SelectTile(Tile.Six);
            SelectTile(Tile.Seven);
            SelectTile(Tile.Eight);
        }

        private void SelectTile(Tile selectedTile)
        {
            if (MemoryGame.TilesSelected == 2)
            {
                MemoryGame.ResetTiles();
                // NotifyOfPropertyChange(() => MemoryGame);
            }
            MemoryGame.SelectTile(selectedTile);
            NotifyChanges();
        }

        private void NotifyChanges()
        {
            NotifyOfPropertyChange(() => MemoryGame);
            NotifyOfPropertyChange(() => MemoryGame.Tile1.Value.Selected);
            NotifyOfPropertyChange(() => MemoryGame.Tile2.Value.Selected);
            NotifyOfPropertyChange(() => MemoryGame.Tile3.Value.Selected);
            NotifyOfPropertyChange(() => MemoryGame.Tile4.Value.Selected);


            NotifyOfPropertyChange(() => CanOpenTile1);
            NotifyOfPropertyChange(() => CanOpenTile2);
            NotifyOfPropertyChange(() => CanOpenTile3);
            NotifyOfPropertyChange(() => CanOpenTile4);
            NotifyOfPropertyChange(() => CanOpenTile5);
            NotifyOfPropertyChange(() => CanOpenTile6);
            NotifyOfPropertyChange(() => CanOpenTile7);
            NotifyOfPropertyChange(() => CanOpenTile8);
            //NotifyOfPropertyChange(()=> TilesSelected);
        }

        public int TilesSelected
        {
            get { return MemoryGame.TilesSelected; }
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