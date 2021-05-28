using Jadcup.Services.Model.QuotationOptionItemModel;

namespace Jadcup.Services.Model.QuotationOptionModel
{
    public class GetQuotationOptionDto
    {
        public string QuotationId { get; set; }
        public string OptionId { get; set; }
        public int? QuotationOptionItemId { get; set; }
        public string CustomizeOptionNotes { get; set; }

        public GetQuotationOptionItemDto QuotationOptionItem { get; set; }
    }
}