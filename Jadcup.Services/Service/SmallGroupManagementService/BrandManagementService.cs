using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.BrandModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class BrandManagementService : IBrandManagementService
    {
        private readonly ICrud<Brand, GetBrandDto, UpdateBrandDto> _crud;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<Brand> _brandRepo;

        public BrandManagementService(ICrud<Brand, GetBrandDto, UpdateBrandDto> crud, IMapper mapper, IGenericMySqlAccessRepository<Brand> genericMySqlAccessRepository)
        {
            _crud = crud;
            _mapper = mapper;
            _brandRepo = genericMySqlAccessRepository;
        }
        public async Task<TaskResponse<bool>> AddBrand(AddBrandDto brand)
        {
            Brand dbBrand = await _brandRepo.GetQueryable().FirstOrDefaultAsync(b => b.BrandName == brand.BrandName);
            return await _crud.AddToTableAsync(dbBrand, brand);
        }

        public async Task<TaskResponse<bool>> DeleteBrand(short id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetBrandDto>>> GetAllBrands()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<GetBrandDto>> GetBrandById(short id)
        {
            return await _crud.GetById(id);
        }

        public async Task<TaskResponse<GetBrandDto>> UpdateBrand(UpdateBrandDto updatedBrand)
        {
            Brand dbBrand = await _brandRepo.GetAsync(updatedBrand.BrandId);
            bool duplicated = (await _brandRepo.GetQueryable().AnyAsync(b => b.BrandName == updatedBrand.BrandName)) && dbBrand.BrandName.ToUpper() != updatedBrand.BrandName.ToUpper();

            return await _crud.UpdateEntry(dbBrand, updatedBrand, duplicated);
        }
    }
}