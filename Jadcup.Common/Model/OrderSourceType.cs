using System;
using System.Collections.Generic;
using System.Text;

namespace Jadcup.Common.Model
{
    /*
     * This class is used for Orders.cs OrderSourceId
     * 0: Order is created by customer;
     * 1: Order is created by employee
     */
    public enum OrderSourceType
    {
        FromCustomer,
        FromEmployee
    }
}
