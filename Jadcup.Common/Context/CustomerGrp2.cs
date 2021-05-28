using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class CustomerGrp2
    {
        public CustomerGrp2()
        {
            Customer = new HashSet<Customer>();
        }

        public short Group2Id { get; set; }
        public string Group2Name { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
