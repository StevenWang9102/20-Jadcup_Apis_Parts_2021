using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class City
    {
        public City()
        {
            Customer = new HashSet<Customer>();
            Orders = new HashSet<Orders>();
        }

        public short CityId { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
