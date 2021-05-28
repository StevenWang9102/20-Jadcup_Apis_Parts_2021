using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Invoice
    {
        public Invoice()
        {
            CreditTransaction = new HashSet<CreditTransaction>();
            InvoiceItem = new HashSet<InvoiceItem>();
            Payment = new HashSet<Payment>();
        }

        public string InvoiceId { get; set; }
        public string InvoiceNo { get; set; }
        public string OrderId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public decimal? TotalPrice { get; set; }
        public ulong? Paid { get; set; }
        public ulong? Emailed { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string Email { get; set; }
        public decimal Credit { get; set; }
        public decimal? PriceInclgst { get; set; }
        public int? CustomerId { get; set; }
        public decimal? PriceInclcredit { get; set; }
        public ulong? Active { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Orders Order { get; set; }
        public virtual ICollection<CreditTransaction> CreditTransaction { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItem { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
