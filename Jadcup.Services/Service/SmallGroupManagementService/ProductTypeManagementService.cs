using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.CommonFunctions;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.ProductTypeModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class ProductTypeManagementService : IProductTypeManagementService
    {
        private readonly ICrud<ProductType, GetProductTypeDto, UpdateProductTypeDto> _crud;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<ProductType> _productTypeRepo;

        public ProductTypeManagementService(ICrud<ProductType, GetProductTypeDto, UpdateProductTypeDto> crud, IMapper mapper, IGenericMySqlAccessRepository<ProductType> genericMySqlAccessRepository)
        {
            _crud = crud;
            _mapper = mapper;
            _productTypeRepo = genericMySqlAccessRepository;
        }
        public async Task<TaskResponse<bool>> Add(AddProductTypeDto request)
        {
            ProductType dbProductType = await _productTypeRepo.GetQueryable().FirstOrDefaultAsync(s => s.ProductTypeName == request.ProductTypeName);
            return await _crud.AddToTableAsync(dbProductType, request);
        }

        public async Task<TaskResponse<bool>> Delete(short id)
        {
            return await _crud.DeleteFromTableAsync(id);
        }

        public async Task<TaskResponse<List<GetProductTypeDto>>> GetAll()
        {
            return await _crud.GetAll();
        }

        public async Task<TaskResponse<GetProductTypeDto>> GetById(short id)
        {
            return await _crud.GetById(id);
        }

        public async Task<TaskResponse<GetProductTypeDto>> Update(UpdateProductTypeDto request)
        {
            ProductType dbProductType = await _productTypeRepo.GetAsync(request.ProductTypeId);
            bool duplicated = (await _productTypeRepo.GetQueryable().AnyAsync(b => b.ProductTypeName == request.ProductTypeName)) && dbProductType.ProductTypeName.ToUpper() != request.ProductTypeName.ToUpper();

            return await _crud.UpdateEntry(dbProductType, request, duplicated);
        }
    }
}