namespace Jadcup.Services.Model.QuotationItemModel
{
    public class UpdateQuotationItemDto
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
    }
}