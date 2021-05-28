using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.QuotationModel;

namespace Jadcup.Services.Interface.QuotationService
{
    public interface IQuotationManagementService
    {
        Task<TaskResponse<List<GetQuotationDto>>> GetAll();
        Task<TaskResponse<GetQuotationDto>> GetById(string id);
        Task<TaskResponse<GetQuotationDto>> GetByQuotaIdAndNo(string id,string QuoteNumber);
        
        Task<TaskResponse<string>> Update(UpdateQuotationDto request);
        Task<TaskResponse<bool>> Delete(string id);
        Task<TaskResponse<bool>> AddAll(AddQuotationDto2 request);
        Task<TaskResponse<bool>> UpdateDraft(UpdateQuotationDto request);
        Task<TaskResponse<List<GetQuotationDto>>> GetByCustomerId(int id, ulong? draft);
    }
}