using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class PoDetail
    {
        public int PoDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? PoId { get; set; }
        public short? RawMaterialId { get; set; }
        public ulong? Completed { get; set; }
        public string Comments { get; set; }
        public decimal? UnitPrice { get; set; }

        public virtual PurchaseOrder Po { get; set; }
        public virtual RawMaterial RawMaterial { get; set; }
    }
}
