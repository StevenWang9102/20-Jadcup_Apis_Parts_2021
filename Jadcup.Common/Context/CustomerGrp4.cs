using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class CustomerGrp4
    {
        public CustomerGrp4()
        {
            Customer = new HashSet<Customer>();
        }

        public short Group4Id { get; set; }
        public string Group4Name { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
