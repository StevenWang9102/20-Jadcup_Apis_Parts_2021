using Jadcup.Common.Model;
using Jadcup.Services.Model.ZoneModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jadcup.Services.Interface.ZoneService
{
    public interface IZoneManagementService
    {
        Task<TaskResponse<List<GetZoneDto2>>> GetAll();
        Task<TaskResponse<GetZoneDto2>> GetById(sbyte id);
        Task<TaskResponse<bool>> Update(UpdateZoneDto request);
        Task<TaskResponse<bool>> Add(AddZoneDto request);
        Task<TaskResponse<bool>> Delete(sbyte id);
    }
}
