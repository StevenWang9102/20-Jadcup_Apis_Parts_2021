using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Orders
    {
        public Orders()
        {
            Dispatching = new HashSet<Dispatching>();
            Invoice = new HashSet<Invoice>();
            OperateLog = new HashSet<OperateLog>();
            OrderOption = new HashSet<OrderOption>();
            OrderProduct = new HashSet<OrderProduct>();
            TicketOrder = new HashSet<Ticket>();
            TicketRedeliveryOrder = new HashSet<Ticket>();
        }

        public int? CustomerId { get; set; }
        public string OrderId { get; set; }
        public string OrderNo { get; set; }
        public int? EmployeeId { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? RequiredDate { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryAddress { get; set; }
        public string PostalCode { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Comments { get; set; }
        public ulong? Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ulong? DeliveryAsap { get; set; }
        public ulong? Paid { get; set; }
        public short? DeliveryCityId { get; set; }
        public sbyte? OrderStatusId { get; set; }
        public short? DeliveryMethodId { get; set; }
        public decimal? PriceInclgst { get; set; }
        public sbyte? OrderSourceId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual City DeliveryCity { get; set; }
        public virtual DeliveryMethod DeliveryMethod { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual OrderSource OrderSource { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual ICollection<Dispatching> Dispatching { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<OperateLog> OperateLog { get; set; }
        public virtual ICollection<OrderOption> OrderOption { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
        public virtual ICollection<Ticket> TicketOrder { get; set; }
        public virtual ICollection<Ticket> TicketRedeliveryOrder { get; set; }
    }
}
