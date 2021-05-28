using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Product
    {
        public Product()
        {
            Box = new HashSet<Box>();
            DispatchingDetails = new HashSet<DispatchingDetails>();
            InvoiceItem = new HashSet<InvoiceItem>();
            Item = new HashSet<Item>();
            OrderProduct = new HashSet<OrderProduct>();
            QuotationItem = new HashSet<QuotationItem>();
            ReturnItem = new HashSet<ReturnItem>();
            WorkOrder = new HashSet<WorkOrder>();
        }

        public short ProductId { get; set; }
        public string ProductName { get; set; }
        public short? BaseProductId { get; set; }
        public ulong Plain { get; set; }
        public string Description { get; set; }
        public int? CustomerId { get; set; }
        public string Images { get; set; }
        public short? PlateTypeId { get; set; }
        public short? MarginOfError { get; set; }
        public short? MinOrderQuantity { get; set; }
        public ulong? Active { get; set; }
        public int? ProductMsl { get; set; }
        public int? SemiMsl { get; set; }
        public ulong? Manufactured { get; set; }
        public sbyte LogoType { get; set; }
        public string LogoUrl { get; set; }
        public short? PalletStackingId { get; set; }
        public string ProductCode { get; set; }

        public virtual BaseProduct BaseProduct { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual PalletStacking PalletStacking { get; set; }
        public virtual PlateType PlateType { get; set; }
        public virtual ICollection<Box> Box { get; set; }
        public virtual ICollection<DispatchingDetails> DispatchingDetails { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItem { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
        public virtual ICollection<QuotationItem> QuotationItem { get; set; }
        public virtual ICollection<ReturnItem> ReturnItem { get; set; }
        public virtual ICollection<WorkOrder> WorkOrder { get; set; }
    }
}
