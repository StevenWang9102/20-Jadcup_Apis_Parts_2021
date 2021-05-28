using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.RawMaterialStockModel;

namespace Jadcup.Services.Interface.RawMaterialStockService
{
    public interface IRawMaterialStockManagementService
    {
        Task<TaskResponse<List<GetRawMaterialStockDto>>> GetAll();
    }
}