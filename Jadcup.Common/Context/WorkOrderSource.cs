using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class WorkOrderSource
    {
        public WorkOrderSource()
        {
            WorkOrder = new HashSet<WorkOrder>();
        }

        public sbyte WorkOrderSourceId { get; set; }
        public string WorkOrderSourceName { get; set; }

        public virtual ICollection<WorkOrder> WorkOrder { get; set; }
    }
}
