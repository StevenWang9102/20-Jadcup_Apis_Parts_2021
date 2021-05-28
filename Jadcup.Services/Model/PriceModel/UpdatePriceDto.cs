namespace Jadcup.Services.Model.PriceModel
{
    public class UpdatePriceDto
    {
        public short? BaseProductId { get; set; }
        public short? Group1Id { get; set; }
        public decimal? MinPrice { get; set; }
        public short PriceId { get; set; }
    }
}