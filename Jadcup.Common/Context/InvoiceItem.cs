using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class InvoiceItem
    {
        public string InvoiceItemId { get; set; }
        public decimal? UnitPrice { get; set; }
        public string InvoiceId { get; set; }
        public short? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
        public short? OptionId { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual ProductOption Option { get; set; }
        public virtual Product Product { get; set; }
    }
}
