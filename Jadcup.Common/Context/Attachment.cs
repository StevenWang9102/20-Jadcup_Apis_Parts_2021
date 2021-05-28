using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Attachment
    {
        public int AttachmentId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? EmployeeId { get; set; }
        public string Urls { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentDesc { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
