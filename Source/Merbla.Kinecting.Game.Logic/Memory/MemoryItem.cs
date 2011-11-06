using System;

namespace Merbla.Kinecting.Game.Logic.Memory
{
    public class MemoryItem : ICloneable

    {
        public MemoryItem()
        {
            Id = Guid.NewGuid();
            Selected = false;
            Matched = false;
        }

        public Guid Id { get; set; }

        public string HiddenText { get; set; }

        public bool Selected { get; set; }

        public bool Matched { get; set; }

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