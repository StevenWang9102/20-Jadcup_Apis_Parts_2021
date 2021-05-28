using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.CustomerModel;

namespace Jadcup.Services.Interface.CustomerService
{
    public interface ICustomerService
    {
        Task<TaskResponse<List<GetCustomerDto>>> GetAll();
        Task<TaskResponse<GetCustomerDto>> GetById(int id);
        Task<TaskResponse<int>> Update(UpdateCustomerDto request);
        Task<TaskResponse<int>> Add(AddCustomerDto request);
        Task<TaskResponse<bool>> Delete(int id);
        Task<TaskResponse<bool>> UpdateStatus(int id, short statusId);

    }
}