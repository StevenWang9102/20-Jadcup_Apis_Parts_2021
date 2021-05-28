using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.MachineTypeModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface IMachineTypeManagementService
    {
        Task<TaskResponse<List<GetMachineTypeDto>>> GetAll();
        Task<TaskResponse<GetMachineTypeDto>> GetById(int id);
        Task<TaskResponse<GetMachineTypeDto>> Update(UpdateMachineTypeDto request);
        Task<TaskResponse<bool>> Add(AddMachineTypeDto request);
        Task<TaskResponse<bool>> Delete(int id);
    }
}