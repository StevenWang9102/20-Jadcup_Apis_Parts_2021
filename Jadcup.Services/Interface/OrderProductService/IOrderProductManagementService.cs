using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.OrderProductModel;

namespace Jadcup.Services.Interface.OrderProductService
{
    public interface IOrderProductManagementService
    {
        Task<TaskResponse<List<GetOrderProductDto>>> GetAll();
        Task<TaskResponse<GetOrderProductDto>> GetById(string id);
        Task<TaskResponse<bool>> Update(UpdateOrderProductDto request);
        Task<TaskResponse<string>> Add(AddOrderProductDto request);
        Task<TaskResponse<bool>> Delete(string id);
    }
}