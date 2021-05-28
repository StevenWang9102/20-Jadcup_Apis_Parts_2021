using System;
using System.Collections.Generic;
using Jadcup.Services.Model.EmployeeModel;
using Jadcup.Services.Model.PoDetailModel;
using Jadcup.Services.Model.PoStatusModel;
using Jadcup.Services.Model.SupplierModel;

namespace Jadcup.Services.Model.PurchaseOrderModel
{
    public class GetPurchaseOrderDto
    {
        public int PoId { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ulong? Active { get; set; }
        public int? CreatedEmployeeId { get; set; }
        public short? SuplierId { get; set; }
        public string PoNo { get; set; }
        public short? PoStatusId { get; set; }

        public GetEmployeeDto CreatedEmployee { get; set; }
        public GetPoStatusDto PoStatus { get; set; }
        public GetSupplierDto2 Suplier { get; set; }
        public List<GetPoDetailDto> PoDetail { get; set; }
    }

    public class GetPurchaseOrderDto2
    {
        public int PoId { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ulong? Active { get; set; }
        public int? CreatedEmployeeId { get; set; }
        public short? SuplierId { get; set; }
        public string PoNo { get; set; }
        public short? PoStatusId { get; set; }
        public List<GetPoDetailDto> PoDetail { get; set; }        
    }
}