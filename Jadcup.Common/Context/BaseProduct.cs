using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class BaseProduct
    {
        public BaseProduct()
        {
            Price = new HashSet<Price>();
            Product = new HashSet<Product>();
            ProductMachineMapping = new HashSet<ProductMachineMapping>();
            ProductPrice = new HashSet<ProductPrice>();
            QuotationItem = new HashSet<QuotationItem>();
        }

        public short BaseProductId { get; set; }
        public string BaseProductName { get; set; }
        public short? ProductTypeId { get; set; }
        public short AmountPerSheet { get; set; }
        public short? RawMaterialId { get; set; }
        public ulong? Active { get; set; }
        public string ProductCode { get; set; }
        public ulong? Manufactured { get; set; }
        public short? PackagingTypeId { get; set; }
        public string Description { get; set; }
        public string RawmaterialDesc { get; set; }
        public short? RawMaterialId2 { get; set; }

        public virtual PackagingType PackagingType { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual RawMaterial RawMaterial { get; set; }
        public virtual RawMaterial RawMaterialId2Navigation { get; set; }
        public virtual ICollection<Price> Price { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<ProductMachineMapping> ProductMachineMapping { get; set; }
        public virtual ICollection<ProductPrice> ProductPrice { get; set; }
        public virtual ICollection<QuotationItem> QuotationItem { get; set; }
    }
}
