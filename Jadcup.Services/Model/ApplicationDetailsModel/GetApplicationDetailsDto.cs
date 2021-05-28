using Jadcup.Services.Model.RawMaterialBoxModel;

namespace Jadcup.Services.Model.ApplicationDetailsModel
{
    public class GetApplicationDetailsDto
    {
        public string ApplicationId { get; set; }
        public string DetailsId { get; set; }
        public string RawMaterialBoxId { get; set; }
        public decimal? Quantity { get; set; }
        public ulong? Runout { get; set; }
        public GetRawMaterialBoxDto RawMaterialBox { get; set; }
    }
}