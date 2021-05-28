using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class ProductType
    {
        public ProductType()
        {
            BaseProduct = new HashSet<BaseProduct>();
            ProductTypeAction = new HashSet<ProductTypeAction>();
        }

        public short ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }

        public virtual ICollection<BaseProduct> BaseProduct { get; set; }
        public virtual ICollection<ProductTypeAction> ProductTypeAction { get; set; }
    }
}
