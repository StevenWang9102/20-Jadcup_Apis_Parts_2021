using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class ExtraAddress
    {
        public short AddressId { get; set; }
        public string Address { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
