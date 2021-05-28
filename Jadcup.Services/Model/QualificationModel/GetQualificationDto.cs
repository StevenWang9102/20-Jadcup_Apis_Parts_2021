using System;

namespace Jadcup.Services.Model.QualificationModel
{
    public class GetQualificationDto
    {
        public short QualificationId { get; set; }
        public DateTime? ExpDate { get; set; }
        public short? SuplierId { get; set; }
        public string QualificationUrls { get; set; }
        public string QualificationName { get; set; }
        public ulong? Active { get; set; }
    }
}