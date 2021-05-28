using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.CustomerStatusModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface ICustomerStatusManagementService
    {
         Task<TaskResponse<List<GetCustomerStatusDto>>> GetAll();
    }
}