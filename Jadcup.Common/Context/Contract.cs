using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Contract
    {
        public string ResouceId { get; set; }
        public short ContractId { get; set; }
        public short? ContractTypeId { get; set; }
        public DateTime? EffDate { get; set; }
        public DateTime? ExpDate { get; set; }
        public DateTime? TrialDate { get; set; }
        public string ContractDesc { get; set; }
        public string Url { get; set; }

        public virtual ContractType ContractType { get; set; }
        public virtual HumanResource Resouce { get; set; }
    }
}
