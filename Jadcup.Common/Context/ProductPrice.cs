using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class ProductPrice
    {
        public int Quantiy { get; set; }
        public decimal? Price { get; set; }
        public string ProductPriceId { get; set; }
        public short? BaseProductId { get; set; }
        public string Description { get; set; }
        public short? Group1Id { get; set; }

        public virtual BaseProduct BaseProduct { get; set; }
        public virtual CustomerGrp1 Group1 { get; set; }
    }
}
