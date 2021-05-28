using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class MachineType
    {
        public MachineType()
        {
            Machine = new HashSet<Machine>();
        }

        public short MachineTypeId { get; set; }
        public string MachineTypeName { get; set; }

        public virtual ICollection<Machine> Machine { get; set; }
    }
}
