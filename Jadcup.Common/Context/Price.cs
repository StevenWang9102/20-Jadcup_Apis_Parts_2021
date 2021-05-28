using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Price
    {
        public short? BaseProductId { get; set; }
        public short? Group1Id { get; set; }
        public decimal? MinPrice { get; set; }
        public short PriceId { get; set; }

        public virtual BaseProduct BaseProduct { get; set; }
        public virtual CustomerGrp1 Group1 { get; set; }
    }
}
