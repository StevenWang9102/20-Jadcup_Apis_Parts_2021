using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            StockLog = new HashSet<StockLog>();
        }

        public short TransactionTypeId { get; set; }
        public string TransactionTypeName { get; set; }

        public virtual ICollection<StockLog> StockLog { get; set; }
    }
}
