using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.ProductTypeActionModel;

namespace Jadcup.Services.Interface.ProductTypeActionService
{
    public interface IProductTypeActionManagementService
    {
         Task<TaskResponse<List<GetProductTypeActionDto>>> GetAll();
         Task<TaskResponse<GetProductTypeActionDto>> GetById(short id);
         Task<TaskResponse<bool>> Update(UpdateProductTypeActionDto request);
         Task<TaskResponse<bool>> Add(AddProductTypeActionDto request);
         Task<TaskResponse<bool>> Delete(short id);
         Task<TaskResponse<List<GetProductTypeActionDto>>> GetActionIdByProductType(short productTypeId, int? OrderTypeId);
    }
}