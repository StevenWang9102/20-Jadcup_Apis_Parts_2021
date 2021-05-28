using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class PlateType
    {
        public PlateType()
        {
            Plate = new HashSet<Plate>();
            Product = new HashSet<Product>();
        }

        public short PlateTypeId { get; set; }
        public string PlateTypeName { get; set; }

        public virtual ICollection<Plate> Plate { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
