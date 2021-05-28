using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.BaseProductService;
using Jadcup.Services.Model.BaseProductModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.BaseProductService
{
    public class BaseProductManagementService : IBaseProductManagementService
    {
        private readonly IGenericMySqlAccessRepository<BaseProduct> _baseProductRepo;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<Price> _priceRepo;
        private readonly IGenericMySqlAccessRepository<CustomerGrp1> _group1Repo;

        public BaseProductManagementService(IGenericMySqlAccessRepository<BaseProduct> baseProductRepo, 
            IMapper mapper,
            IGenericMySqlAccessRepository<Price> priceRepo,
            IGenericMySqlAccessRepository<CustomerGrp1> group1Repo)
        {
            _priceRepo = priceRepo;
            _group1Repo = group1Repo;
            _mapper = mapper;
            _baseProductRepo = baseProductRepo;

        }
        public async Task<TaskResponse<short>> Add(AddBaseProductDto request)
        {
            TaskResponse<short> response = new TaskResponse<short>();
            BaseProduct bp = await _baseProductRepo.GetQueryable().Where(b => b.Active == 1).FirstOrDefaultAsync(b => b.BaseProductName == request.BaseProductName);

            if (bp != null)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, SystemMessage.DuplicateError());
            }

            BaseProduct added = _mapper.Map<BaseProduct>(request);
            added.Active = 1;
            _baseProductRepo.Insert(added);
            await _baseProductRepo.SaveAsync();

            response.Data = added.BaseProductId;
            return response;
        }

        public async Task<TaskResponse<bool>> Delete(short id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            BaseProduct bp = await _baseProductRepo.GetQueryable().Where(b => b.Active == 1).FirstOrDefaultAsync(b => b.BaseProductId == id);

            if (bp == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            bp.Active = 0;
            _baseProductRepo.UpdateT(bp);
            await _baseProductRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetBaseProductDto>>> GetAll()
        {
            TaskResponse<List<GetBaseProductDto>> response = new TaskResponse<List<GetBaseProductDto>>();
            List<BaseProduct> bps = await _baseProductRepo.GetQueryable()
                .Where(b => b.Active == 1)
                .Include(b => b.ProductType)
                .Include(b => b.RawMaterial)
                .Include(b => b.Price).ThenInclude(p => p.Group1)
                .Include(b => b.ProductPrice)
                .Include(b => b.PackagingType)
                .ToListAsync();

            response.Data = bps.Select(b => _mapper.Map<GetBaseProductDto>(b)).ToList();
            return response;
        }

        public async Task<TaskResponse<GetBaseProductDto>> GetById(short id)
        {
            TaskResponse<GetBaseProductDto> response = new TaskResponse<GetBaseProductDto>();
            BaseProduct bp = await _baseProductRepo.GetQueryable().Where(b => b.Active == 1)
            .Include(b => b.ProductType)
            .Include(b => b.RawMaterial)
            .Include(b => b.Price).ThenInclude(p => p.Group1)
            .Include(b => b.ProductPrice)            
            .Include(b => b.PackagingType)
            .FirstOrDefaultAsync(b => b.BaseProductId == id);

            response.Data = _mapper.Map<GetBaseProductDto>(bp);
            return response;
        }

        public async Task<TaskResponse<bool>> Update(UpdateBaseProductDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            BaseProduct bp = await _baseProductRepo.GetQueryable().Where(b => b.Active == 1).FirstOrDefaultAsync(b => b.BaseProductId == request.BaseProductId);

            if (bp == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _mapper.Map(request, bp);
            _baseProductRepo.UpdateT(bp);
            await _baseProductRepo.SaveAsync();

            response.Data = true;
            return response;
        }
    }
}