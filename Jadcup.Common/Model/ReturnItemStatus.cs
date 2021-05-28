using System;
using System.Collections.Generic;
using System.Text;

namespace Jadcup.Common.Model
{

    /*This class is used for ReturnItem.cs Processed.
     *It is to show the status of a returnItem.
     * 
     * Receipted: items returned to warehouse,
     * Destroyed: items wrong or damaged, not retured to warehouse.
     * 
     */
    public enum ReturnItemStatus
    {
        Receipted,
        Destroyed
    }
}
