
using Jadcup.Services.Model.BaseProductModel;
using static Jadcup.Services.Model.CustomerGroupModel.CustomerGroup1;

namespace Jadcup.Services.Model.PriceModel
{
    public class GetPriceDto
    {
        public short? BaseProductId { get; set; }
        public short? Group1Id { get; set; }
        public decimal? MinPrice { get; set; }
        public short PriceId { get; set; }

        public GetBaseProductDto2 BaseProduct { get; set; }
        public GetGroup1Dto Group1 { get; set; }
    }

    public class GetPriceDto2
    {
        public short? Group1Id { get; set; }
        public decimal? MinPrice { get; set; }
        public short PriceId { get; set; }
        public GetGroup1Dto Group1 { get; set; }
    }
}