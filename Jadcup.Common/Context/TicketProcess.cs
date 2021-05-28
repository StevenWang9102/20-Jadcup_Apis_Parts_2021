using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class TicketProcess
    {
        public string ProcessId { get; set; }
        public string TicketId { get; set; }
        public int? AssignedEmployeeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Comments { get; set; }
        public DateTime? CompletedAt { get; set; }
        public ulong? Processed { get; set; }

        public virtual Employee AssignedEmployee { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
