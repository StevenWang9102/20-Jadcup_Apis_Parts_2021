using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class ProductOption
    {
        public ProductOption()
        {
            InvoiceItem = new HashSet<InvoiceItem>();
            OrderOption = new HashSet<OrderOption>();
        }

        public short OptionId { get; set; }
        public string OptionName { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItem { get; set; }
        public virtual ICollection<OrderOption> OrderOption { get; set; }
    }
}
