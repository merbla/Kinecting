using System;
using Caliburn.Micro;

namespace Merbla.Kinecting.Game.Logic.Memory
{
  
    public class MemoryItem : PropertyChangedBase, ICloneable
    {
        private Guid _id;
        private bool _matched;
        private bool _selected;

        public MemoryItem()
        {
            //TODO: Remove Caliburn and move to AOP for INotifyPropertyChanged
            Id = Guid.NewGuid();
            Selected = false;
            Matched = false;
        }

        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        public string HiddenText { get; set; }

        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                NotifyOfPropertyChange(() => Selected);
            }
        }

        public bool Matched
        {
            get { return _matched; }
            set
            {
                _matched = value;
                NotifyOfPropertyChange(() => Matched);
            }
        }

        public string Text { get; set; }

        public int TileNumber { get; set; }


        public Tile Tile
        {
            get
            {
                var tile = (Tile) Enum.Parse(typeof (Tile), TileNumber.ToString());
                return tile;
            }
        }

        public byte[] Image { get; set; }

        public byte[] HiddenImage { get; set; }

        #region ICloneable Members

        public object Clone()
        {
            return MemberwiseClone();
        }

        #endregion
    }
}