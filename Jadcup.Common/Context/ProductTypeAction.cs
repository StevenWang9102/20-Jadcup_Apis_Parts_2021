using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class ProductTypeAction
    {
        public short ProductTypeActionId { get; set; }
        public short? ProductTypeId { get; set; }
        public short? ActionId { get; set; }
        public int? OrderTypeId { get; set; }
        public sbyte? SequenceNo { get; set; }

        public virtual Action Action { get; set; }
        public virtual OrderType OrderType { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
