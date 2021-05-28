using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Cell
    {
        public Cell()
        {
            ShelfPlate = new HashSet<ShelfPlate>();
        }

        public short CellId { get; set; }
        public short? ShelfId { get; set; }
        public short RowNo { get; set; }
        public short? ColNo { get; set; }
        public ulong? Active { get; set; }

        public virtual Shelf Shelf { get; set; }
        public virtual ICollection<ShelfPlate> ShelfPlate { get; set; }
    }
}
