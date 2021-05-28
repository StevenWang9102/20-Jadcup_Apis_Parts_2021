using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.OrderStatusModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface IOrderStatusManagementService
    {
         Task<TaskResponse<List<GetOrderStatusDto>>> GetAll();
         Task<TaskResponse<GetOrderStatusDto>> GetById(sbyte id);
    } 
}