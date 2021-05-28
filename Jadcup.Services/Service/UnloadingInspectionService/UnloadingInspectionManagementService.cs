using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.UnloadingInspectionService;
using Jadcup.Services.Model.PlateModel;
using Jadcup.Services.Model.RawMaterialBoxModel;
using Jadcup.Services.Model.UnloadingInspectionModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.UnloadingInspectionService
{
    public class UnloadingInspectionManagementService : IUnloadingInspectionManagementService
    {
        private readonly IGenericMySqlAccessRepository<UnloadingInspection> _unloadingInspectionRepo;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<RawMaterialBox> _rawMaterialBoxRepo;
        private readonly IGenericMySqlAccessRepository<PlateBox> _plateBoxRepo;
        private readonly IGenericMySqlAccessRepository<BaseProduct> _baseProduct;

        public UnloadingInspectionManagementService(
            IGenericMySqlAccessRepository<UnloadingInspection> unloadingInspectionRepo,
            IMapper mapper,
            IGenericMySqlAccessRepository<RawMaterialBox> rawMaterialBoxRepo,
            IGenericMySqlAccessRepository<PlateBox> plateBoxRepo,
            IGenericMySqlAccessRepository<BaseProduct> baseProductRepo)
        {
            _unloadingInspectionRepo = unloadingInspectionRepo;
            _mapper = mapper;
            _rawMaterialBoxRepo = rawMaterialBoxRepo;
            _plateBoxRepo = plateBoxRepo;
            _baseProduct = baseProductRepo;
        }
        public async Task<TaskResponse<string>> Add(AddUnloadingInspectionDto request)
        {
            TaskResponse<string> response = new TaskResponse<string>();

            UnloadingInspection ui = _mapper.Map<UnloadingInspection>(request);
            ui.InspectionId = Guid.NewGuid().ToString();

            _unloadingInspectionRepo.Insert(ui);
            await _unloadingInspectionRepo.SaveAsync();

            response.Data = ui.InspectionId;
            return response;
        }

        public async Task<TaskResponse<bool>> Delete(string id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            UnloadingInspection ui = await _unloadingInspectionRepo.GetAsync(id);
            if (ui == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }
            try {
                _unloadingInspectionRepo.Delete(ui);
                await _unloadingInspectionRepo.SaveAsync();
            }catch{
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage("Can not Delete this Row ,May be good already into warehouse"));
            }
            
            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetUnloadingInspectionDto2>>> GetAll(int? poId, DateTime? unloadingDateStart, DateTime? unloadingDateEnd)
        {
            TaskResponse<List<GetUnloadingInspectionDto2>> response = new TaskResponse<List<GetUnloadingInspectionDto2>>();
            List<GetUnloadingInspectionDto2> results = new List<GetUnloadingInspectionDto2>();

            List<UnloadingInspection> uis = await _unloadingInspectionRepo.GetQueryable()
                .Include(u => u.Box).ThenInclude(b =>b.Product)
                .Include(u => u.Po).ThenInclude(po => po.PoDetail)
                .Where(u => poId == null || u.PoId == poId)
                .Where(u => unloadingDateStart == null || u.UnloadingDate >= unloadingDateStart)
                .Where(u => unloadingDateEnd == null || u.UnloadingDate <= unloadingDateEnd)
                .Include(u => u.Po)
                .ToListAsync();
            
            foreach (UnloadingInspection ui in uis)
            {
                GetUnloadingInspectionDto2 dto = _mapper.Map<GetUnloadingInspectionDto2>(ui);

                List<RawMaterialBox> rmbs = await _rawMaterialBoxRepo.GetQueryable()
                    .Where(r => r.InspectionId == ui.InspectionId)
                    .Include(r => r.RawMaterial)
                    .ToListAsync();

                List<GetRawMaterialBoxDto3> rmbDtos = new List<GetRawMaterialBoxDto3>();
                
                foreach (RawMaterialBox rmb in rmbs)
                {
                    GetRawMaterialBoxDto3 rmbDto = _mapper.Map<GetRawMaterialBoxDto3>(rmb);

                    PlateBox plateBox = await _plateBoxRepo.GetQueryable().Include(pb => pb.Plate).ThenInclude(p => p.PlateType).FirstOrDefaultAsync(pb => pb.RawMaterialBoxId == rmb.RawMaterialBoxId && pb.Active == 1);
                    if (plateBox == null)
                    {
                        rmbDto.PlateId = null;
                        rmbDto.PlateId = null;
                    }
                    else
                    {
                        rmbDto.PlateId = plateBox.PlateId;
                        rmbDto.Plate = _mapper.Map<GetPlateDto>(plateBox.Plate);
                    }
                    rmbDtos.Add(rmbDto);
                }

                dto.RawMaterialBox = rmbDtos;

                results.Add(dto);
            }

            response.Data = results;
            return response;
        }

        public async Task<TaskResponse<GetUnloadingInspectionDto>> GetById(string id)
        {
            TaskResponse<GetUnloadingInspectionDto> response = new TaskResponse<GetUnloadingInspectionDto>();

            UnloadingInspection ui = await _unloadingInspectionRepo.GetQueryable()
                // .Include(u => u.Po)
                .Include(u => u.Po).ThenInclude(po => po.PoDetail).ThenInclude(pod => pod.RawMaterial)                
                .FirstOrDefaultAsync(r => r.InspectionId == id);
            if (ui == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            GetUnloadingInspectionDto dto = _mapper.Map<GetUnloadingInspectionDto>(ui);

            List<RawMaterialBox> rmbs = await _rawMaterialBoxRepo.GetQueryable()
                    .Where(r => r.InspectionId == ui.InspectionId)
                    .Include(r => r.RawMaterial)
                    .ToListAsync();
            dto.RawMaterialBox = rmbs.Select(r => _mapper.Map<GetRawMaterialBoxDto>(r)).ToList();

            foreach (var pot in dto.Po.PoDetail){
                // pot.RawMaterialId
                var baseProds = await _baseProduct.GetQueryable().
                    Where(bp => bp.RawMaterialId == pot.RawMaterialId && bp.Active==1)
                    .Include(bp => bp.PackagingType).ToListAsync();
                var baseProd =baseProds.FirstOrDefault() ;
                if (baseProd==null){
                    pot.OutSourceProd = false;
                    pot.PackagingQty = 0;
                    continue;
                }
                if (baseProds.Where( bp => bp.Manufactured == 0).Count()>0 &&
                    baseProds.Where( bp => bp.Manufactured == 1).Count()>0)
                    throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage("Product configuration error!"));

                if ( baseProd.Manufactured == 0 ) {
                    pot.OutSourceProd = false;
                    pot.PackagingQty = 0;
                    continue;
                }
                if (baseProd.PackagingType ==null &&baseProd.PackagingType.Quantity==null)
                    throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage("Package configuration error!"));
                if ( baseProd.Manufactured == 1 ) {
                    pot.OutSourceProd = true;
                    pot.PackagingQty = baseProd.PackagingType.Quantity;
                }
            }
            response.Data = dto;
            return response;
        }

        public async Task<TaskResponse<bool>> Update(UpdateUnloadingInspectionDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            UnloadingInspection ui = await _unloadingInspectionRepo.GetAsync(request.InspectionId);
            if (ui == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _mapper.Map(request, ui);
            _unloadingInspectionRepo.UpdateT(ui);
            await _unloadingInspectionRepo.SaveAsync();

            response.Data = true;
            return response;
        }
    }
}