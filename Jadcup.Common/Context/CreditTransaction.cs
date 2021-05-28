using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class CreditTransaction
    {
        public string InvoiceId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string TicketId { get; set; }
        public string Notes { get; set; }
        public int? CustomerId { get; set; }

        public virtual CustomerCredit Customer { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
