using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.BrandModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface IBrandManagementService
    {
        Task<TaskResponse<List<GetBrandDto>>> GetAllBrands();
        Task<TaskResponse<GetBrandDto>> GetBrandById(short id);
        Task<TaskResponse<GetBrandDto>> UpdateBrand(UpdateBrandDto updatedBrand);
        Task<TaskResponse<bool>> AddBrand(AddBrandDto brand);
        Task<TaskResponse<bool>> DeleteBrand(short id);
    }
}