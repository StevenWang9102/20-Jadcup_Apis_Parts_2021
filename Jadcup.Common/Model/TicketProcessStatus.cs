using System;
using System.Collections.Generic;
using System.Text;

namespace Jadcup.Common.Model
{
    /* This class is used for TicketProcess.cs Processed.
     * It is to show the status of a ticketProcess.
     * 
     * 0 -- Processing: process created with assigned employee
     * 1 -- Closed: process created without assigned employee
     */

    public enum TicketProcessStatus
    {
        Processing,
        Closed
    }
}
