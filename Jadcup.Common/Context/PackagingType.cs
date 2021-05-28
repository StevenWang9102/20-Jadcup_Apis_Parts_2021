using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class PackagingType
    {
        public PackagingType()
        {
            BaseProduct = new HashSet<BaseProduct>();
        }

        public short PackagingTypeId { get; set; }
        public string PackagingTypeName { get; set; }
        public short? Quantity { get; set; }
        public short? SleeveQty { get; set; }
        public short? SleevePkt { get; set; }

        public virtual ICollection<BaseProduct> BaseProduct { get; set; }
    }
}
