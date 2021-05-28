using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class ContractType
    {
        public ContractType()
        {
            Contract = new HashSet<Contract>();
        }

        public short ContractTypeId { get; set; }
        public string ContractTypeName { get; set; }

        public virtual ICollection<Contract> Contract { get; set; }
    }
}
