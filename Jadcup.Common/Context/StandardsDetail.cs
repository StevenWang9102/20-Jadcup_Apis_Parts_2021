using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class StandardsDetail
    {
        public StandardsDetail()
        {
            AccessmentDetail = new HashSet<AccessmentDetail>();
        }

        public string AcceStandDetailId { get; set; }
        public string Item { get; set; }
        public decimal Max { get; set; }
        public string AcceStandardId { get; set; }
        public int? Weight { get; set; }

        public virtual AccessmentStandards AcceStandard { get; set; }
        public virtual ICollection<AccessmentDetail> AccessmentDetail { get; set; }
    }
}
