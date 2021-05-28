using System;
using System.Collections.Generic;
using System.Text;

namespace Jadcup.Common.Model
{
    /* This class is used for Ticket.cs Closed,
     * showing the ticket is open or not.
     * 
     * 0-Open: at least one process is processing.
     * 1-Closed: all processes are closed.
     */
    public enum TicketStatus
    {
        Open,
        Closed
    }
}
