using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class OrderOption
    {
        public string OrderId { get; set; }
        public short? OptionId { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Price { get; set; }
        public string OrderOptionId { get; set; }

        public virtual ProductOption Option { get; set; }
        public virtual Orders Order { get; set; }
    }
}
