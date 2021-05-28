using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Page
    {
        public Page()
        {
            RolePageMapping = new HashSet<RolePageMapping>();
        }

        public short PageId { get; set; }
        public string PageName { get; set; }
        public string PageUrl { get; set; }
        public short? SortingOrder { get; set; }
        public short? GroupId { get; set; }

        public virtual PageGroup Group { get; set; }
        public virtual ICollection<RolePageMapping> RolePageMapping { get; set; }
    }
}
