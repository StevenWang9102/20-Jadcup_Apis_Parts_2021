using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Standard
    {
        public Standard()
        {
            InspectionPlan = new HashSet<InspectionPlan>();
        }

        public short StandardId { get; set; }
        public string StandardContent { get; set; }

        public virtual ICollection<InspectionPlan> InspectionPlan { get; set; }
    }
}
