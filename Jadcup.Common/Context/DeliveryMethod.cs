using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class DeliveryMethod
    {
        public DeliveryMethod()
        {
            Customer = new HashSet<Customer>();
            Orders = new HashSet<Orders>();
        }

        public short DeliveryMethodId { get; set; }
        public string DeliveryMethodName { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
