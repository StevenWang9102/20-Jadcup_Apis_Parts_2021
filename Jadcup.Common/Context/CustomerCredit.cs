using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class CustomerCredit
    {
        public CustomerCredit()
        {
            CreditTransaction = new HashSet<CreditTransaction>();
        }

        public int CustomerId { get; set; }
        public decimal Credit { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<CreditTransaction> CreditTransaction { get; set; }
    }
}
