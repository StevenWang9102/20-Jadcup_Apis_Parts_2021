using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.PlateTypeModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface IPlateTypeManagementService
    {
        Task<TaskResponse<List<GetPlateTypeDto>>> GetAll();
        Task<TaskResponse<GetPlateTypeDto>> GetById(short id);
        Task<TaskResponse<GetPlateTypeDto>> Update(UpdatePlateTypeDto request);
        Task<TaskResponse<bool>> Add(AddPlateTypeDto request);
        Task<TaskResponse<bool>> Delete(short id);
    }
}