using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Quotation
    {
        public Quotation()
        {
            OperateLog = new HashSet<OperateLog>();
            QuotationItem = new HashSet<QuotationItem>();
            QuotationOption = new HashSet<QuotationOption>();
        }

        public string QuotationId { get; set; }
        public ulong? Draft { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? EffDate { get; set; }
        public DateTime? ExpDate { get; set; }
        public int? EmployeeId { get; set; }
        public ulong? Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string QuotationNo { get; set; }
        public string Notes { get; set; }
        public DateTime? CustConfimedAt { get; set; }
        public ulong? CustConfirmed { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<OperateLog> OperateLog { get; set; }
        public virtual ICollection<QuotationItem> QuotationItem { get; set; }
        public virtual ICollection<QuotationOption> QuotationOption { get; set; }
    }
}
