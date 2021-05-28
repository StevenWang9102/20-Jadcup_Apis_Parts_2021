using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.ProductOptionModel;

namespace Jadcup.Services.Interface.ProductOptionService
{
    public interface IProductOptionManagementService
    {
        Task<TaskResponse<List<GetProductOptionDto>>> GetAll();
        Task<TaskResponse<GetProductOptionDto>> GetById(short id);
        Task<TaskResponse<short>> Add(AddProductOptionDto request);
        Task<TaskResponse<bool>> Update(UpdateProductOptionDto request);
        Task<TaskResponse<bool>> Delete(short id);    
    }
}