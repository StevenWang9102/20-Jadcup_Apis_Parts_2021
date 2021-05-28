using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Shelf
    {
        public Shelf()
        {
            Cell = new HashSet<Cell>();
        }

        public short ShelfId { get; set; }
        public string ShelfCode { get; set; }
        public short Position { get; set; }
        public short? TotalRows { get; set; }
        public short? TotalCols { get; set; }
        public sbyte? ZoneId { get; set; }
        public ulong? Active { get; set; }

        public virtual Zone Zone { get; set; }
        public virtual ICollection<Cell> Cell { get; set; }
    }
}
