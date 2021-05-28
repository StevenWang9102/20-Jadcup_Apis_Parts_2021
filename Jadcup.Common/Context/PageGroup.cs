using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class PageGroup
    {
        public PageGroup()
        {
            Page = new HashSet<Page>();
        }

        public short GroupId { get; set; }
        public string GroupName { get; set; }
        public short? SortingOrder { get; set; }

        public virtual ICollection<Page> Page { get; set; }
    }
}
