using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Stock
    {
        public Stock()
        {
            StockLog = new HashSet<StockLog>();
        }

        public short StockId { get; set; }
        public decimal Quantity { get; set; }
        public short? ItemId { get; set; }

        public virtual Item Item { get; set; }
        public virtual ICollection<StockLog> StockLog { get; set; }
    }
}
