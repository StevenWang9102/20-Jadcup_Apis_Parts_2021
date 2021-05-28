using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Courier
    {
        public Courier()
        {
            Dispatching = new HashSet<Dispatching>();
        }

        public sbyte CourierId { get; set; }
        public string CourierName { get; set; }

        public virtual ICollection<Dispatching> Dispatching { get; set; }
    }
}
