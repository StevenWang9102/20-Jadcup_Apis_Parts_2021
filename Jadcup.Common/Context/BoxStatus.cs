using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class BoxStatus
    {
        public BoxStatus()
        {
            Box = new HashSet<Box>();
        }

        public sbyte StatusId { get; set; }
        public string BoxStatusName { get; set; }

        public virtual ICollection<Box> Box { get; set; }
    }
}
