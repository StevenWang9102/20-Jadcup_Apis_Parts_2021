using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class PaymentCycle
    {
        public PaymentCycle()
        {
            Customer = new HashSet<Customer>();
        }

        public short PaymentCycleId { get; set; }
        public string PaymentCycleName { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
