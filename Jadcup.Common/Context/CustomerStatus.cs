using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class CustomerStatus
    {
        public CustomerStatus()
        {
            Customer = new HashSet<Customer>();
        }

        public short StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
