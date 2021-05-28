using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class Suplier
    {
        public Suplier()
        {
            PurchaseOrder = new HashSet<PurchaseOrder>();
            Qualification = new HashSet<Qualification>();
            SuplierRawMaterial = new HashSet<SuplierRawMaterial>();
        }

        public short SuplierId { get; set; }
        public string SuplierName { get; set; }
        public sbyte SuplierType { get; set; }
        public ulong? Active { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual ICollection<Qualification> Qualification { get; set; }
        public virtual ICollection<SuplierRawMaterial> SuplierRawMaterial { get; set; }
    }
}
