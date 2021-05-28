using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.QuotationOptionModel;

namespace Jadcup.Services.Interface.QuotationOptionManagementService
{
    public interface IQuotationOptionManagementService
    {
         Task<TaskResponse<List<GetQuotationOptionDto>>> GetAll();
         Task<TaskResponse<GetQuotationOptionDto>> GetById(string id);
         Task<TaskResponse<bool>> Add(AddQuotationOptionDto request);
         Task<TaskResponse<bool>> Update(UpdateQuotationOptionDto request);
         Task<TaskResponse<bool>> Delete(string id);
    }
}