using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Dispatching
    {
        public Dispatching()
        {
            DispatchingDetails = new HashSet<DispatchingDetails>();
        }

        public string OrderId { get; set; }
        public string DispatchId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public string TrackingNo { get; set; }
        public sbyte? CourierId { get; set; }
        public sbyte? Status { get; set; }
        public sbyte? SourceType { get; set; }

        public virtual Courier Courier { get; set; }
        public virtual Orders Order { get; set; }
        public virtual DispatchingStatus StatusNavigation { get; set; }
        public virtual ICollection<DispatchingDetails> DispatchingDetails { get; set; }
    }
}
