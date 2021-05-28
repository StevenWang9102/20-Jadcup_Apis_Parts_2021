using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class CustomerGrp3
    {
        public CustomerGrp3()
        {
            Customer = new HashSet<Customer>();
        }

        public short Group3Id { get; set; }
        public string Group3Name { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
