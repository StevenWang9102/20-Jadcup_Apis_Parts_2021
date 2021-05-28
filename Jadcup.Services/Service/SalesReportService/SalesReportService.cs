using Jadcup.Common.Repository;
using System;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Common.Context;
using Microsoft.EntityFrameworkCore;
using Jadcup.Services.Interface.SalesReportService;
using Jadcup.Services.Model.SalesReportModel;
using Jadcup.Services.Model.CustomerModel;

namespace Jadcup.Services.Service.SalesReportService
{
    public class SalesReportService : ISalesReportService
    {
        private readonly IGenericMySqlAccessRepository<Invoice> _invoiceRepo;
        private readonly IGenericMySqlAccessRepository<Customer> _customerRepo;
        private readonly IGenericMySqlAccessRepository<Orders> _orderRepo;
        private readonly IMapper _mapper;
        public SalesReportService(IGenericMySqlAccessRepository<Invoice> invoiceRepo, IGenericMySqlAccessRepository<Orders> orderRepo, IGenericMySqlAccessRepository<Customer> customerRepo, IMapper mapper)
        {
            _mapper = mapper;
            _invoiceRepo = invoiceRepo;
            _customerRepo = customerRepo;
            _orderRepo = orderRepo;
        }

        public async Task<TaskResponse<List<SaleReportResult>>> GetSalesReportByCustomer(int? id, bool? isInvoice, DateTime? startDateTime, DateTime? endDateTime)
        {
            TaskResponse<List<SaleReportResult>> response = new TaskResponse<List<SaleReportResult>>();
            List<SaleReportResult> myResult = new List<SaleReportResult> { };

            if (id != null)
            {
                // 如果选择客户，则显示这一个时间段内，每个月份的明细总数
                List<Invoice> invoices = await _invoiceRepo.GetQueryable()
                .Include(c => c.Order)
                .Include(c => c.Customer)
                .Where(c => c.CustomerId == id)
                .Where(o => startDateTime == null || o.CreatedAt >= startDateTime)
                .Where(o => endDateTime == null || o.CreatedAt <= endDateTime)
                .ToListAsync();

                var filtedInvoices = invoices.Select(c => _mapper.Map<GetSalesReportDto>(c)).ToList();

                for(int i = 0; i < filtedInvoices.Count(); i++) 
                {
                    SaleReportResult temp = new SaleReportResult { };
                    var invoiceMonth = filtedInvoices[i].InvoiceDate.ToString("MM/yyyy");
                    temp.CustomerId = id;
                    temp.Month = invoiceMonth;
                    temp.Sum = filtedInvoices[i].TotalPrice;

                    var indexFound = myResult.FindIndex(x => x.Month.Equals(invoiceMonth));
                    
                    if (indexFound > -1)
                    {
                        myResult[indexFound].Sum = myResult[indexFound].Sum + filtedInvoices[i].TotalPrice;
                    }
                    else
                    {
                        myResult.Add(temp);
                    }
                }
            }
            else
            {
                // 如果没有选择客户，则显示，每个客户, 在这个大时间段内的总数据。 
                List<Invoice> invoices = await _invoiceRepo.GetQueryable()
                .Include(c => c.Order)
                .Include(c => c.Customer)
                .Where(o => startDateTime == null || o.CreatedAt >= startDateTime)
                .Where(o => endDateTime == null || o.CreatedAt <= endDateTime)
                .ToListAsync();

                var filtedInvoices = invoices.Select(c => _mapper.Map<GetSalesReportDto>(c)).ToList();

                foreach (GetSalesReportDto each in filtedInvoices)
                {
                    SaleReportResult temp = new SaleReportResult { };
                    temp.CustomerId = each.CustomerId;
                    temp.Sum = each.TotalPrice;
                    temp.Month = "";
                    myResult.Add(temp);
                }

         }

            response.Data = myResult;
            return response;
        }

        public async Task<TaskResponse<List<GetSalesReportBySalesDto>>> GetSalesReportByEmplyee(int emplyeeId, bool? isInvoice, DateTime? startDateTime, DateTime? endDateTime)
        {
            TaskResponse<List<GetSalesReportBySalesDto>> response = new TaskResponse<List<GetSalesReportBySalesDto>>();

            List<Invoice> invoices = await _invoiceRepo.GetQueryable()
                .Include(c => c.Order)
                   .ThenInclude(c => c.Employee)
                .Where(c => c.Order.EmployeeId == emplyeeId)
                .Where(o => startDateTime == null || o.CreatedAt >= startDateTime)
                .Where(o => endDateTime == null || o.CreatedAt <= endDateTime)
                .ToListAsync();

            response.Data = invoices.Select(c => _mapper.Map<GetSalesReportBySalesDto>(c)).ToList();
            return response;
        }

        public async Task<TaskResponse<List<CustomerExistDto>>> GetNoSalesReportOfCustomerInThreeMonth()
        {
            TaskResponse<List<CustomerExistDto>> response = new TaskResponse<List<CustomerExistDto>>();

            var startDateTime = DateTime.Now.ToLocalTime().AddMonths(-3);
            var endDateTime = DateTime.Now.ToLocalTime();

            // Find exit customer list
            List<Invoice> invoices = await _invoiceRepo.GetQueryable()
                .Include(c => c.Order)
                .Include(c => c.Customer)
                .Where(c => c.CreatedAt >= startDateTime)
                .Where(o => o.CreatedAt <= endDateTime)
                .ToListAsync();

            var existCustomersList = invoices
                .Select(c => _mapper.Map<CustomerExistDto>(c))
                .Select(c => c.CustomerId.ToString())
                .ToList();

            // Find all customer list.
            List<Customer> customers = await _customerRepo.GetQueryable().ToListAsync();
            List<CustomerExistDto> allCustomersList = customers.Select(c => _mapper.Map<CustomerExistDto>(c)).ToList();

            // Filter
            List<CustomerExistDto> notExistCustomers = new List<CustomerExistDto> { };
            notExistCustomers = allCustomersList.Where(each => !existCustomersList.Contains(each.CustomerId.ToString())).ToList();

            response.Data = notExistCustomers;
            return response;
        }


    }
}
