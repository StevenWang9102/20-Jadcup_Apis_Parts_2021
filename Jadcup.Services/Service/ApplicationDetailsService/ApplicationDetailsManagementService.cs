using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.ApplicationDetailsManagementService;
using Jadcup.Services.Model.ApplicationDetailsModel;
using Jadcup.Services.Model.RawMaterialBoxModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.ApplicationDetailsService
{
    public class ApplicationDetailsManagementService : IApplicationDetailsManagementService
    {
        private readonly IGenericMySqlAccessRepository<ApplicationDetails> _applicationDetailsRepo;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<Product> _productRepo;
        private readonly IGenericMySqlAccessRepository<RawMaterialApplication> _rawMaterialApplicationRepo;
        private readonly IGenericMySqlAccessRepository<PlateBox> _plateBoxRepo;

        public ApplicationDetailsManagementService(
            IGenericMySqlAccessRepository<ApplicationDetails> applicationDetailsRepo,
            IMapper mapper,
            IGenericMySqlAccessRepository<Product> productRepo,
            IGenericMySqlAccessRepository<RawMaterialApplication> rawMaterialApplicationRepo,
            IGenericMySqlAccessRepository<PlateBox> plateBoxRepo)
        {
            _productRepo = productRepo;
            _rawMaterialApplicationRepo = rawMaterialApplicationRepo;
            _plateBoxRepo = plateBoxRepo;
            _mapper = mapper;
            _applicationDetailsRepo = applicationDetailsRepo;

        }
        public async Task<TaskResponse<string>> Add(AddApplicationDetailsDto request)
        {
            TaskResponse<string> response = new TaskResponse<string>();

            string id = AddApplicationDetails(request);
            await _applicationDetailsRepo.SaveAsync();

            response.Data = id;
            return response;

        }

        public async Task<TaskResponse<bool>> Delete(string id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            ApplicationDetails ad = await _applicationDetailsRepo.GetAsync(id);

            if (ad == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _applicationDetailsRepo.Delete(ad);
            await _applicationDetailsRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetApplicationDetailsDto>>> GetAll(string applicationId, ulong? runout, DateTime? start, DateTime? end)
        {
            TaskResponse<List<GetApplicationDetailsDto>> response = new TaskResponse<List<GetApplicationDetailsDto>>();

            List<ApplicationDetails> details = await _applicationDetailsRepo.GetQueryable()
                .Include(d => d.Application)
                .Include(d => d.RawMaterialBox)
                    .ThenInclude(rmb => rmb.RawMaterial)
                .Where(d => applicationId == null || d.ApplicationId == applicationId)
                .Where(d => runout == null || d.Runout == runout)
                .Where(d => start == null || d.Application.ReceivedAt >= start)
                .Where(d => end == null || d.Application.ReceivedAt <= end)
                .OrderByDescending(d => d.Application.AppliedAt)
                .ToListAsync();

            response.Data = details.Select(d => _mapper.Map<GetApplicationDetailsDto>(d)).ToList();
            return response;
        }

        public async Task<TaskResponse<GetApplicationDetailsDto>> GetById(string id)
        {
            TaskResponse<GetApplicationDetailsDto> response = new TaskResponse<GetApplicationDetailsDto>();

            ApplicationDetails detail = await _applicationDetailsRepo.GetAsync(id);
            if (detail == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            response.Data = _mapper.Map<GetApplicationDetailsDto>(detail);
            return response;
        }

        public async Task<TaskResponse<bool>> MarkRunout(string id, ulong runout)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            ApplicationDetails detail = await _applicationDetailsRepo.GetAsync(id);
            if (detail == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            detail.Runout = runout;
            _applicationDetailsRepo.UpdateT(detail);

            PlateBox plateBox = await _plateBoxRepo.GetQueryable().FirstOrDefaultAsync(pb => pb.RawMaterialBoxId == detail.RawMaterialBoxId && pb.Active == 1);
            if (plateBox != null)
            {
                plateBox.Active = 1;
                plateBox.UpdatedAt = DateTime.UtcNow;
                _plateBoxRepo.UpdateT(plateBox);
            }
            
            await _applicationDetailsRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<List<GetRawMaterialBoxDto>>>> GetActiveRawMaterialBoxByProductId(short productId)
        {
            TaskResponse<List<List<GetRawMaterialBoxDto>>> response = new TaskResponse<List<List<GetRawMaterialBoxDto>>>();

            var product = (await _productRepo.GetQueryable().
                    Include(p => p.BaseProduct).ThenInclude(b => b.RawMaterial).
                    Include(p => p.BaseProduct).ThenInclude(b => b.RawMaterialId2Navigation).
                    FirstOrDefaultAsync(p => p.ProductId == productId));
            if (product==null)  
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            var baseProduct = product.BaseProduct;
            RawMaterial rawMaterial1 = baseProduct.RawMaterial;
            RawMaterial rawMaterial2 = baseProduct.RawMaterialId2Navigation;

            List<RawMaterial> rawMaterials = new List<RawMaterial>(); 

            rawMaterials.Add(rawMaterial1);
            if (rawMaterial2!=null)  rawMaterials.Add(rawMaterial2);
            List<RawMaterialApplication> rawMaterialapplications = new List<RawMaterialApplication>();
            List<ApplicationDetails> details =  new List<ApplicationDetails> ();
            List<RawMaterialBox> boxes = new List<RawMaterialBox>();
            List<List<GetRawMaterialBoxDto>> resData = new List<List<GetRawMaterialBoxDto>>();

            foreach (var rawMaterial in rawMaterials)
            {
                rawMaterialapplications = await _rawMaterialApplicationRepo.GetQueryable().Where(rm => rm.RawMaterialId == rawMaterial.RawMaterialId && rm.Active == 1 && rm.RecievedQuantity != null).ToListAsync();

                details = await _applicationDetailsRepo.GetQueryable().Where(d => rawMaterialapplications.Select(rm => rm.ApplicationId).ToList().Contains(d.ApplicationId) && d.Runout != 1).Include(d => d.RawMaterialBox).ToListAsync();
                boxes = details.Select(d => d.RawMaterialBox).Where(d => d!=null).ToList();                
                resData.Add(boxes.Select(b => _mapper.Map<GetRawMaterialBoxDto>(b)).ToList());  
            }
            response.Data = resData;
            return response;
        }

        //function
        public string AddApplicationDetails(AddApplicationDetailsDto request)
        {
            Guid id = Guid.NewGuid();
            ApplicationDetails ad = _mapper.Map<ApplicationDetails>(request);
            ad.DetailsId = id.ToString();
            ad.Runout = 0;

            _applicationDetailsRepo.Insert(ad);
            return id.ToString();
        }


    }
}
