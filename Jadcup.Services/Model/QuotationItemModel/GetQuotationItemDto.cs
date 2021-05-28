using Jadcup.Services.Model.BaseProductModel;
using Jadcup.Services.Model.ProductModel;

namespace Jadcup.Services.Model.QuotationItemModel
{
    public class GetQuotationItemDto
    {
        public short? ProductId { get; set; }
        public string QuotationItemId { get; set; }
        public decimal? Price { get; set; }
        public short? BaseProductId { get; set; }
        public string QuotationId { get; set; }
        public decimal? CartonPrice { get; set; }
         public ulong? IsLowerPrice { get; set; }
        public string ItemDesc { get; set; }
        public int Notes { get; set; }
        public string Notes2 { get; set; }
        public decimal? OriginPrice { get; set; }

        public GetBaseProductDto2 BaseProduct { get; set; }
        public GetProductDto2 Product { get; set; }
    }

    public class GetQuotationItemDto2
    {
        public short? ProductId { get; set; }
        public string QuotationItemId { get; set; }
        public decimal? Price { get; set; }
        public short? BaseProductId { get; set; }
        public string QuotationId { get; set; }
        public ulong? Active { get; set; }
        public decimal? CartonPrice { get; set; }
        public ulong? IsLowerPrice { get; set; }
        public string ItemDesc { get; set; }
        public int Notes { get; set; }
        public string Notes2 { get; set; }
        public decimal? OriginPrice { get; set; }

        public GetBaseProductDto3 BaseProduct { get; set; }
        public GetProductDto4 Product { get; set; }
    }
}
