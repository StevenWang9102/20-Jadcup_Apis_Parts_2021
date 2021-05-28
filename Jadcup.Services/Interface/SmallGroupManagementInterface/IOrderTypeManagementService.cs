using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.OrderTypeModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface IOrderTypeManagementService
    {
        Task<TaskResponse<List<GetOrderTypeDto>>> GetAll();
    }
}