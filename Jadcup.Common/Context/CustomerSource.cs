using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class CustomerSource
    {
        public CustomerSource()
        {
            Customer = new HashSet<Customer>();
        }

        public short SourceId { get; set; }
        public string SourceName { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
