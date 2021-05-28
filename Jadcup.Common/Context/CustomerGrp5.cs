using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class CustomerGrp5
    {
        public CustomerGrp5()
        {
            Customer = new HashSet<Customer>();
        }

        public short Group5Id { get; set; }
        public string Group5Name { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
