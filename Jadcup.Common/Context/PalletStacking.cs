using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class PalletStacking
    {
        public PalletStacking()
        {
            Product = new HashSet<Product>();
        }

        public short PalletStackingId { get; set; }
        public string PalletStackingName { get; set; }
        public int Quantity { get; set; }
        public string LayoutImage { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
