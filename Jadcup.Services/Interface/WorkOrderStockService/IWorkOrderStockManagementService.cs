using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.InventoryWorkOrderModel;

namespace Jadcup.Services.Interface.WorkOrderStockService
{
    public interface IWorkOrderStockManagementService
    {
         Task<TaskResponse<List<GetInventoryWorkOrderDto>>> GetAll(bool? low);

         Task<TaskResponse<GetInventoryWorkOrderDto>> GetByProductId(short productId);
         
    }
}