using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Action
    {
        public Action()
        {
            ProductMachineMapping = new HashSet<ProductMachineMapping>();
            ProductTypeAction = new HashSet<ProductTypeAction>();
            Suborder = new HashSet<Suborder>();
        }

        public short ActionId { get; set; }
        public string ActionName { get; set; }

        public virtual ICollection<ProductMachineMapping> ProductMachineMapping { get; set; }
        public virtual ICollection<ProductTypeAction> ProductTypeAction { get; set; }
        public virtual ICollection<Suborder> Suborder { get; set; }
    }
}
