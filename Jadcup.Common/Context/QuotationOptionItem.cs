using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class QuotationOptionItem
    {
        public QuotationOptionItem()
        {
            QuotationOption = new HashSet<QuotationOption>();
        }

        public int QuotationOptionItemId { get; set; }
        public string QuotationOptionItemName { get; set; }

        public virtual ICollection<QuotationOption> QuotationOption { get; set; }
    }
}
