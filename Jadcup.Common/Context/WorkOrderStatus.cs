using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class WorkOrderStatus
    {
        public WorkOrderStatus()
        {
            WorkOrder = new HashSet<WorkOrder>();
        }

        public sbyte WorkOrderStatusId { get; set; }
        public string WorkOrderStatusName { get; set; }

        public virtual ICollection<WorkOrder> WorkOrder { get; set; }
    }
}
