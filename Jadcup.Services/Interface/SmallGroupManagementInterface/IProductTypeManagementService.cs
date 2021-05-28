using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.ProductTypeModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface IProductTypeManagementService
    {
        Task<TaskResponse<List<GetProductTypeDto>>> GetAll();
        Task<TaskResponse<GetProductTypeDto>> GetById(short id);
        Task<TaskResponse<GetProductTypeDto>> Update(UpdateProductTypeDto request);
        Task<TaskResponse<bool>> Add(AddProductTypeDto request);
        Task<TaskResponse<bool>> Delete(short id);
    }
}