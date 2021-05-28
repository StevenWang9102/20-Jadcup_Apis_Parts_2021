using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class OperateLog
    {
        public string LogId { get; set; }
        public string Notes { get; set; }
        public string QuotationId { get; set; }
        public string OrderId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Orders Order { get; set; }
        public virtual Quotation Quotation { get; set; }
    }
}
