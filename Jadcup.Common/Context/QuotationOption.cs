using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class QuotationOption
    {
        public string QuotationId { get; set; }
        public string OptionId { get; set; }
        public int? QuotationOptionItemId { get; set; }
        public string CustomizeOptionNotes { get; set; }

        public virtual Quotation Quotation { get; set; }
        public virtual QuotationOptionItem QuotationOptionItem { get; set; }
    }
}
