using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class StockLog
    {
        public string LogId { get; set; }
        public short? StockId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Comments { get; set; }
        public int? EmployeeId { get; set; }
        public short? TransactionTypeId { get; set; }
        public string BoxId { get; set; }
        public string RawMaterialBoxId { get; set; }

        public virtual Box Box { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual RawMaterialBox RawMaterialBox { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}
