using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.ProductMachineMappingModel;

namespace Jadcup.Services.Interface.ProductMachineMappingService
{
    public interface IProductMachineMappingManagementService
    {
        Task<TaskResponse<List<GetProductMachineMappingDto>>> GetAll(short? baseProductId, short? machineId);
        Task<TaskResponse<short>> Add(AddProductMachineMappingDto request);
        Task<TaskResponse<bool>> Delete(short id);
    }
}