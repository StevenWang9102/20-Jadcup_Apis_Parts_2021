using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class CustomerGrp1
    {
        public CustomerGrp1()
        {
            Customer = new HashSet<Customer>();
            Price = new HashSet<Price>();
            ProductPrice = new HashSet<ProductPrice>();
        }

        public short Group1Id { get; set; }
        public string Group1Name { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Price> Price { get; set; }
        public virtual ICollection<ProductPrice> ProductPrice { get; set; }
    }
}
