using System;
using System.Collections.Generic;

namespace Jadcup.Common.Context
{
    public partial class TicketType
    {
        public TicketType()
        {
            Ticket = new HashSet<Ticket>();
        }

        public sbyte TicketType1 { get; set; }
        public string TicketTypeName { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
