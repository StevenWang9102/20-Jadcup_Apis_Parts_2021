
using System.Collections.Generic;
using Jadcup.Services.Model.PoDetailModel;

namespace Jadcup.Services.Model.PurchaseOrderModel
{
    public class AddPurchaseOrderDto
    {
        public decimal Price { get; set; }
        public int? CreatedEmployeeId { get; set; }
        public short? SuplierId { get; set; }
        public string PoNo { get; set; }

        public List<AddPoDetailDto> PoDetail { get; set; }
    }
}