using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class PoStatus
    {
        public PoStatus()
        {
            PurchaseOrder = new HashSet<PurchaseOrder>();
        }

        public short PoStatusId { get; set; }
        public string PoStatusName { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
