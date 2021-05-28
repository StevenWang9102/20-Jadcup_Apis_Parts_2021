using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.QuotationItemModel;

namespace Jadcup.Services.Interface.QuotationItemService
{
    public interface IQuotationItemManagementService
    {
         Task<TaskResponse<List<GetQuotationItemDto>>> GetAll();
         Task<TaskResponse<GetQuotationItemDto>> GetById(string id);
         Task<TaskResponse<bool>> Add(AddQuotationItemDto request);
         Task<TaskResponse<bool>> Update(UpdateQuotationItemDto request);
         Task<TaskResponse<bool>> Delete(string id);
    }
}