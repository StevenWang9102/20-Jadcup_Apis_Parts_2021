using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.CityModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class CityManagementService : ICityManagementService
    {
        private readonly ICrud<City, GetCityDto, UpdateCityDto> _crud;
        private readonly IGenericMySqlAccessRepository<City> _cityRepo;
        private readonly IMapper _mapper;
        public CityManagementService(ICrud<City, GetCityDto, UpdateCityDto> crud, IGenericMySqlAccessRepository<City> genericMySqlAccessRepository, IMapper mapper)
        {
            _crud = crud;
            _cityRepo = genericMySqlAccessRepository;
            _mapper = mapper;
        }
        public async Task<TaskResponse<bool>> AddCity(AddCityDto city)
        {
            City dbCity = await _cityRepo.GetQueryable().FirstOrDefaultAsync(c => c.CityName == city.CityName);
            return await _crud.AddToTableAsync(dbCity, city);
        }

        public async Task<TaskResponse<bool>> DeleteCity(short id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }
        public async Task<TaskResponse<List<GetCityDto>>> GetAllCities()
        {
            return await _crud.GetAll();
        }
        public async Task<TaskResponse<GetCityDto>> GetCityById(short id)
        {
            return await _crud.GetById(id);
        }

        public async Task<TaskResponse<GetCityDto>> UpdateCity(UpdateCityDto updatedCity)
        {
            City dbCity = await _cityRepo.GetAsync(updatedCity.CityId);
            bool duplicated = (await _cityRepo.GetQueryable().AnyAsync(b => b.CityName == updatedCity.CityName)) && dbCity.CityName.ToUpper() != updatedCity.CityName.ToUpper();
            
            return await _crud.UpdateEntry(dbCity, updatedCity, duplicated);
        }
    }
}