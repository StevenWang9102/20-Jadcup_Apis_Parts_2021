using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Brand
    {
        public Brand()
        {
            Customer = new HashSet<Customer>();
        }

        public short BrandId { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
