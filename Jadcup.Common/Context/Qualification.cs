using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Qualification
    {
        public short QualificationId { get; set; }
        public DateTime? ExpDate { get; set; }
        public short? SuplierId { get; set; }
        public string QualificationUrls { get; set; }
        public string QualificationName { get; set; }
        public ulong? Active { get; set; }

        public virtual Suplier Suplier { get; set; }
    }
}
