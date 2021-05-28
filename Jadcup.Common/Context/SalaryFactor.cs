using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class SalaryFactor
    {
        public string ResouceId { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal? Bonus { get; set; }
        public decimal? BonusRate { get; set; }
        public short? QuarterId { get; set; }
        public decimal? Facter1 { get; set; }
        public decimal? Facter2 { get; set; }
        public decimal? Facter3 { get; set; }
        public decimal? Facter4 { get; set; }
        public decimal? Facter5 { get; set; }

        public virtual Quarter Quarter { get; set; }
        public virtual HumanResource Resouce { get; set; }
    }
}
