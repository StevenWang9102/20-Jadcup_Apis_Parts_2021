using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class HumanResource
    {
        public HumanResource()
        {
            AttachedRecord = new HashSet<AttachedRecord>();
            Contract = new HashSet<Contract>();
        }

        public string ResouceId { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public string Phone { get; set; }
        public sbyte? Status { get; set; }
        public string Notes { get; set; }
        public DateTime? EntryDate { get; set; }
        public short? Role { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

        public virtual SalaryFactor SalaryFactor { get; set; }
        public virtual ICollection<AttachedRecord> AttachedRecord { get; set; }
        public virtual ICollection<Contract> Contract { get; set; }
    }
}
