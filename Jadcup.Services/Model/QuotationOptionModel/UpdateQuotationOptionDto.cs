namespace Jadcup.Services.Model.QuotationOptionModel
{
    public class UpdateQuotationOptionDto
    {
        public string QuotationId { get; set; }
        public string OptionId { get; set; }
        public int? QuotationOptionItemId { get; set; }
        public string CustomizeOptionNotes { get; set; }

    }
}