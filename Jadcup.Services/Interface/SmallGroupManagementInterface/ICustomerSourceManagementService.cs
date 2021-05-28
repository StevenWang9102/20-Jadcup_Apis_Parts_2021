using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.CustomerSourceModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface ICustomerSourceManagementService
    {
        Task<TaskResponse<List<GetCustomerSourceDto>>> GetAll();
        Task<TaskResponse<GetCustomerSourceDto>> GetById(short id);
        Task<TaskResponse<GetCustomerSourceDto>> Update(UpdateCustomerSourceDto request);
        Task<TaskResponse<bool>> Add(AddCustomerSourceDto request);
        Task<TaskResponse<bool>> Delete(short id);
    }
}