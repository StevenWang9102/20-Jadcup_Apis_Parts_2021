namespace Jadcup.Services.Model.PriceModel
{
    public class AddPriceDto
    {
        public short? BaseProductId { get; set; }
        public short? Group1Id { get; set; }
        public decimal? MinPrice { get; set; }
    }
}