using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class DailyReport
    {
        public int? EmployeeId { get; set; }
        public string DailyReportId { get; set; }
        public decimal Loss { get; set; }
        public string Reason { get; set; }
        public short? MachineId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string ReportId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Machine Machine { get; set; }
    }
}
