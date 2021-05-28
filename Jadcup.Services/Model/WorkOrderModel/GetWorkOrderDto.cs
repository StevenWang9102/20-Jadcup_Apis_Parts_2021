using System;
using Jadcup.Services.Model.EmployeeModel;
using Jadcup.Services.Model.OrderProductModel;
using Jadcup.Services.Model.OrderTypeModel;
using Jadcup.Services.Model.ProductModel;
using Jadcup.Services.Model.WorkOrderSourceModel;
using Jadcup.Services.Model.WorkOrderStatusModel;
using Jadcup.Services.Model.ActionModel;

namespace Jadcup.Services.Model.WorkOrderModel
{
    public class GetWorkOrderDto
    {
        public string OrderProductId { get; set; }
        public string WorkOrderId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public short? ProductId { get; set; }
        public int? CreatedEmployeeId { get; set; }
        public string Comments { get; set; }
        public string ApprovedComments { get; set; }
        public int? ApprovedEmployeeId { get; set; }
        public int? OrderTypeId { get; set; }
        public ulong? Urgent { get; set; }
        public DateTime? RequiredDate { get; set; }
        public int Quantity { get; set; }
        public sbyte? WorkOrderStatusId { get; set; }
        public sbyte? WorkOrderSourceId { get; set; }
        public string WorkOrderNo { get; set; }
        public GetActionDto ActionDto {get;set;}

        public GetEmployeeDto2 CreatedEmployee { get; set; }
        public GetOrderProductDto2 OrderProduct { get; set; }
        public GetOrderTypeDto OrderType { get; set; }
        public GetProductDto2 Product { get; set; }
        public GetWorkOrderSourceDto WorkOrderSource { get; set; }
        public GetWorkOrderStatusDto WorkOrderStatus { get; set; }

    }

    public class GetWorkOrderDto2
    {
        public string OrderProductId { get; set; }
        public string WorkOrderId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public short? ProductId { get; set; }
        public int? CreatedEmployeeId { get; set; }
        public string Comments { get; set; }
        public string ApprovedComments { get; set; }
        public int? ApprovedEmployeeId { get; set; }
        public int? OrderTypeId { get; set; }
        public ulong? Urgent { get; set; }
        public DateTime? RequiredDate { get; set; }
        public int Quantity { get; set; }
        public sbyte? WorkOrderStatusId { get; set; }
        public sbyte? WorkOrderSourceId { get; set; }
        public string WorkOrderNo { get; set; }
        public GetProductDto4 Product { get; set; }
    }
}