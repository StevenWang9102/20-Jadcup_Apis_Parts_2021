using System;
using System.Collections.Generic;
using System.Text;

namespace Jadcup.Services.Model.ProductPriceModel
{
    public class UpdateProductPriceDto
    {
        public int Quantiy { get; set; }
        public decimal? Price { get; set; }
        public string ProductPriceId { get; set; }
        public short? BaseProductId { get; set; }
        public string Description { get; set; }
        public short? Group1Id { get; set; }        
    }
}