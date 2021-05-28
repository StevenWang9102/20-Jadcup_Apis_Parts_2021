using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.BaseProductModel;

namespace Jadcup.Services.Interface.BaseProductService
{
    public interface IBaseProductManagementService
    {
         Task<TaskResponse<List<GetBaseProductDto>>> GetAll();
         Task<TaskResponse<GetBaseProductDto>> GetById(short id);
         Task<TaskResponse<bool>> Update(UpdateBaseProductDto request);
         Task<TaskResponse<short>> Add(AddBaseProductDto request);
         Task<TaskResponse<bool>> Delete(short id);
    }
}