using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.BoxModel;
using Jadcup.Services.Model.ReturnItemModel;

namespace Jadcup.Services.Interface.ReturnItemService
{
    public interface IReturnItemManagementService
    {
        Task<TaskResponse<List<GetReturnItemDto>>> GetAll(string ticketId, sbyte? processed);
        Task<TaskResponse<GetReturnItemDto>> GetById(int id);
        Task<TaskResponse<int>> Add(AddReturnItemDto request);
        Task<TaskResponse<bool>> Update(UpdateReturnItemDto request);
        Task<TaskResponse<List<string>>> Process(UpdateReturnItemDto2 request);
        Task<TaskResponse<bool>> Delete(int id);
        Task<TaskResponse<string>> AddBox(AddBoxDto request);
    }
}