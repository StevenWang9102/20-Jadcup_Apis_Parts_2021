using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class RecordType
    {
        public RecordType()
        {
            AttachedRecord = new HashSet<AttachedRecord>();
        }

        public sbyte RecordTypeId { get; set; }
        public string RecordTypeName { get; set; }

        public virtual ICollection<AttachedRecord> AttachedRecord { get; set; }
    }
}
