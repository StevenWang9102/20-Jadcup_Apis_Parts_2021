using Jadcup.Common.Model;
using Jadcup.Services.Model.CustomerModel;
using Jadcup.Services.Model.SalesReportModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jadcup.Services.Interface.SalesReportService
{
    public interface ISalesReportService
    {
        Task<TaskResponse<List<SaleReportResult>>> GetSalesReportByCustomer(int? customerId, bool? isInvoice, DateTime? startDateTime, DateTime? endDateTime);
        Task<TaskResponse<List<GetSalesReportBySalesDto>>> GetSalesReportByEmplyee(int customerId, bool? isInvoice, DateTime? startDateTime, DateTime? endDateTime);
        Task<TaskResponse<List<CustomerExistDto>>> GetNoSalesReportOfCustomerInThreeMonth();
    }
}
