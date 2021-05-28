using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Item
    {
        public short ItemId { get; set; }
        public sbyte ItemType { get; set; }
        public short? RawMaterialId { get; set; }
        public short? ProductId { get; set; }
        public ulong? IsSemi { get; set; }

        public virtual Product Product { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
