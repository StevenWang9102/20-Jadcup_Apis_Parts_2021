using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class ApplicationDetails
    {
        public string ApplicationId { get; set; }
        public string DetailsId { get; set; }
        public string RawMaterialBoxId { get; set; }
        public decimal? Quantity { get; set; }
        public ulong? Runout { get; set; }

        public virtual RawMaterialApplication Application { get; set; }
        public virtual RawMaterialBox RawMaterialBox { get; set; }
    }
}
