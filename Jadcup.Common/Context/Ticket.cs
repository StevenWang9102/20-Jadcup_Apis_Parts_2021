using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Ticket
    {
        public Ticket()
        {
            Box = new HashSet<Box>();
            CreditTransaction = new HashSet<CreditTransaction>();
            ReturnItem = new HashSet<ReturnItem>();
            TicketProcess = new HashSet<TicketProcess>();
        }

        public string TicketId { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public string ContactNo { get; set; }
        public string ContectPerson { get; set; }
        public sbyte? TicketType { get; set; }
        public ulong? Closed { get; set; }
        public string Result { get; set; }
        public string OrderId { get; set; }
        public decimal? ReturnCredit { get; set; }
        public ulong? Redelivery { get; set; }
        public ulong? Destroyed { get; set; }
        public string RedeliveryOrderId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Orders Order { get; set; }
        public virtual Orders RedeliveryOrder { get; set; }
        public virtual TicketType TicketTypeNavigation { get; set; }
        public virtual ICollection<Box> Box { get; set; }
        public virtual ICollection<CreditTransaction> CreditTransaction { get; set; }
        public virtual ICollection<ReturnItem> ReturnItem { get; set; }
        public virtual ICollection<TicketProcess> TicketProcess { get; set; }
    }
}
