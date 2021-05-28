using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class AccessmentDetail
    {
        public string AccessmentDetailId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Notes { get; set; }
        public string AccessmentId { get; set; }
        public string AcceStandDetailId { get; set; }

        public virtual AccessmentStandardsDetail AcceStandDetail { get; set; }
        public virtual Accessment Accessment { get; set; }
    }
}
