using System;

namespace Jadcup.Services.Model.QualificationModel
{
    public class AddQualificationDto
    {
        public DateTime? ExpDate { get; set; }
        public short? SuplierId { get; set; }
        public string QualificationUrls { get; set; }
        public string QualificationName { get; set; }
    }
}