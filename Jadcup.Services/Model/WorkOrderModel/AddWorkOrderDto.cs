using System;

namespace Jadcup.Services.Model.WorkOrderModel
{
    public class AddWorkOrderDto
    {
        public string OrderProductId { get; set; }
        public short? ProductId { get; set; }
        public int? CreatedEmployeeId { get; set; }
        public string Comments { get; set; }
        public string ApprovedComments { get; set; }
        public int? ApprovedEmployeeId { get; set; }
        public int? OrderTypeId { get; set; }
        public ulong? Urgent { get; set; }
        public DateTime? RequiredDate { get; set; }
        public int Quantity { get; set; }
        public sbyte? WorkOrderSourceId { get; set; }
        public sbyte? WorkOrderStatusId { get; set; }
    }
}