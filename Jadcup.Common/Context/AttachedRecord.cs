using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class AttachedRecord
    {
        public string ResouceId { get; set; }
        public string AttachedId { get; set; }
        public sbyte? RecordTypeId { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual RecordType RecordType { get; set; }
        public virtual HumanResource Resouce { get; set; }
    }
}
