using System.Collections.Generic;
using Jadcup.Services.Model.PoDetailModel;

namespace Jadcup.Services.Model.PurchaseOrderModel
{
    public class UpdatePurchaseOrderDto
    {
        public int PoId { get; set; }
        public decimal Price { get; set; }
        public short? SuplierId { get; set; }
        public string PoNo { get; set; }

        public List<AddPoDetailDto> PoDetail { get; set; }
    }
}