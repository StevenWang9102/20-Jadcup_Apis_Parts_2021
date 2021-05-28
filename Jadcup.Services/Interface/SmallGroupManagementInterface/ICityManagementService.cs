using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.CityModel;

namespace Jadcup.Services.Interface.SmallGroupManagementInterface
{
    public interface ICityManagementService
    {
        Task<TaskResponse<List<GetCityDto>>> GetAllCities();
        Task<TaskResponse<GetCityDto>> GetCityById(short id);
        Task<TaskResponse<GetCityDto>> UpdateCity(UpdateCityDto request);
        Task<TaskResponse<bool>> AddCity(AddCityDto request);
        Task<TaskResponse<bool>> DeleteCity(short id);
    }
}