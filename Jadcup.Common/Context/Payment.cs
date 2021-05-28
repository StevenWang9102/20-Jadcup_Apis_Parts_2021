using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Payment
    {
        public string PaymentId { get; set; }
        public string InvoiceId { get; set; }
        public DateTime? Amount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? PaymentMethod { get; set; }
        public int CardId { get; set; }
        public string TxnId { get; set; }
        public int Success { get; set; }
        public string ClientInfo { get; set; }
        public string ResponseText { get; set; }
        public string AmountSettlement { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string DateExpiry { get; set; }
        public string CardHolderName { get; set; }
        public string CurrencySettlement { get; set; }
        public string CurrencyInput { get; set; }
        public string TxnMac { get; set; }
        public string Url { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
