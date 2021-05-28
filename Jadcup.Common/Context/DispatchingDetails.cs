using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class DispatchingDetails
    {
        public string DetailId { get; set; }
        public string DispatchId { get; set; }
        public string BoxId { get; set; }
        public short? ProductId { get; set; }
        public int? Quantity { get; set; }
        public ulong? IsWhole { get; set; }

        public virtual Box Box { get; set; }
        public virtual Dispatching Dispatch { get; set; }
        public virtual Product Product { get; set; }
    }
}
