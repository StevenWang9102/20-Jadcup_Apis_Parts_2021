using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class ProductMachineMapping
    {
        public short MappingId { get; set; }
        public short? MachineId { get; set; }
        public short? BaseProductId { get; set; }
        public short? ActionId { get; set; }

        public virtual Action Action { get; set; }
        public virtual BaseProduct BaseProduct { get; set; }
        public virtual Machine Machine { get; set; }
    }
}
