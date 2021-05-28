using System;

namespace Jadcup.Services.Model.RawMaterialApplicationModel
{
    public class AddRawMaterialApplicationDto
    {
        public int? ApplyEmployeeId { get; set; }
        public short? RawMaterialId { get; set; }
        public decimal? ApplyQuantity { get; set; }
    }
}