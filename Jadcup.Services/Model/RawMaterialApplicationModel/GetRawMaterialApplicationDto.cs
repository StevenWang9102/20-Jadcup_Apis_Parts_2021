using System;
using System.Collections.Generic;
using Jadcup.Services.Model.ApplicationDetailsModel;
using Jadcup.Services.Model.EmployeeModel;
using Jadcup.Services.Model.RawMaterialModel;

namespace Jadcup.Services.Model.RawMaterialApplicationModel
{
    public class GetRawMaterialApplicationDto
    {
        public string ApplicationId { get; set; }
        public int? ApplyEmployeeId { get; set; }
        public int? WarehouseEmployeeId { get; set; }
        public DateTime? AppliedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public short? RawMaterialId { get; set; }
        public decimal? ApplyQuantity { get; set; }
        public decimal? ReceivedQuantity { get; set; }
        public ulong? Processed { get; set; }

        public GetEmployeeDto2 ApplyEmployee { get; set; }
        public GetRawMaterialDto RawMaterial { get; set; }
        public GetEmployeeDto2 WarehouseEmployee { get; set; }
        public List<GetApplicationDetailsDto> ApplicationDetails { get; set; }
    }
}