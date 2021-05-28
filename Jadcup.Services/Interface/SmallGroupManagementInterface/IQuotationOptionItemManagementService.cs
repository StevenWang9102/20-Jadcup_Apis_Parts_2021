using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.QuotationOptionItemModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface IQuotationOptionItemManagementService
    {
        Task<TaskResponse<List<GetQuotationOptionItemDto>>> GetAll();
        Task<TaskResponse<GetQuotationOptionItemDto>> GetById(int id);
        Task<TaskResponse<GetQuotationOptionItemDto>> Update(UpdateQuotationOptionItemDto request);
        Task<TaskResponse<bool>> Add(AddQuotationOptionItemDto request);
        Task<TaskResponse<bool>> Delete(int id);
    }
}