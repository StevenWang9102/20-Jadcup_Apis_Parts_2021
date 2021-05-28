using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.InvoiceModel;

namespace Jadcup.Services.Interface.InvoiceService
{
    public interface IInvoiceManagementService
    {
        Task<TaskResponse<List<GetInvoiceDto>>> GetAll(string orderId, int? customerId, ulong? active); 
        Task<TaskResponse<GetInvoiceDto>> GetSingle(string invoiceId, string invoiceNo);
        Task<TaskResponse<bool>> AddInvoice(string orderId);
        Task<TaskResponse<bool>> UpdateInvoice(UpdateInvoiceDto request);
        Task<TaskResponse<bool>> DeleteInvoice(string invoiceId);
        Task<TaskResponse<bool>> MarkPaid(string id, ulong paid);
        Task<TaskResponse<bool>> MarkEmailed(string id, ulong emailed);
    }
}