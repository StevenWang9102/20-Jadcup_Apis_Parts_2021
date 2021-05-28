using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.PackagingTypeModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface IPackagingTypeManagementService
    {
        Task<TaskResponse<List<GetPackagingTypeDto>>> GetAll();
        Task<TaskResponse<GetPackagingTypeDto>> GetById(short id);
        Task<TaskResponse<GetPackagingTypeDto>> Update(UpdatePackagingTypeDto request);
        Task<TaskResponse<bool>> Add(AddPackagingTypeDto request);
        Task<TaskResponse<bool>> Delete(short id);
    }
}