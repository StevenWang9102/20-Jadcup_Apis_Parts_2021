using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SupplierRawMaterialService;
using Jadcup.Services.Model.QualificationModel;
using Jadcup.Services.Model.RawMaterialModel;
using Jadcup.Services.Model.SupplierModel;
using Jadcup.Services.Model.SupplierRawMaterialModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SupplierRawMaterialService
{
    public class SupplierRawMaterialManagementService : ISupplierRawMaterialManagementService
    {
        private readonly IGenericMySqlAccessRepository<SuplierRawMaterial> _supplierRawMaterialRepo;
        private readonly IGenericMySqlAccessRepository<Suplier> _supplierRepo;
        private readonly IGenericMySqlAccessRepository<RawMaterial> _rawMaterialRepo;
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<Qualification> _qualificationRepo;

        public SupplierRawMaterialManagementService(
            IGenericMySqlAccessRepository<SuplierRawMaterial> supplierRawMaterialRepo,
            IGenericMySqlAccessRepository<Suplier> supplierRepo,
            IGenericMySqlAccessRepository<RawMaterial> rawMaterialRepo,
            IMapper mapper,
            IGenericMySqlAccessRepository<Qualification> qualificationRepo)
        {
            _supplierRawMaterialRepo = supplierRawMaterialRepo;
            _supplierRepo = supplierRepo;
            _rawMaterialRepo = rawMaterialRepo;
            _mapper = mapper;
            _qualificationRepo = qualificationRepo;
        }
        public async Task<TaskResponse<int>> Add(AddSupplierRawMaterialDto request)
        {
            TaskResponse<int> response = new TaskResponse<int>();

            bool duplicated = await _supplierRawMaterialRepo.GetQueryable().AnyAsync(sr => sr.SuplierId == request.SuplierId && sr.RawMaterialId == request.RawMaterialId);
            if (duplicated)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, SystemMessage.DuplicateError());
            }

            SuplierRawMaterial srm = _mapper.Map<SuplierRawMaterial>(request);
            _supplierRawMaterialRepo.Insert(srm);
            await _supplierRawMaterialRepo.SaveAsync();

            response.Data = srm.SuplierRawMaterialId;
            return response;
        }

        public async Task<TaskResponse<bool>> Delete(DeleteSupplierRawMaterialDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            SuplierRawMaterial srm = await _supplierRawMaterialRepo.GetQueryable().FirstOrDefaultAsync(srm => srm.RawMaterialId == request.RawMaterialId && srm.SuplierId == request.SuplierId);
            if (srm == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _supplierRawMaterialRepo.Delete(srm);
            await _supplierRawMaterialRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetSupplierRawMaterialDto>>> GetAll(short? supplierId, short? rawMaterialId)
        {
            TaskResponse<List<GetSupplierRawMaterialDto>> response = new TaskResponse<List<GetSupplierRawMaterialDto>>();

            List<SuplierRawMaterial> srms = await _supplierRawMaterialRepo.GetQueryable()
                .Where(s => rawMaterialId == null || s.RawMaterialId == rawMaterialId)
                .Where(s => supplierId == null || s.SuplierId == supplierId)
                .ToListAsync();

            response.Data = srms.Select(s => _mapper.Map<GetSupplierRawMaterialDto>(s)).ToList();
            return response;
        }

        public async Task<TaskResponse<List<GetRawMaterialDto>>> GetRawMaterialBySupplierId(short supplierId)
        {
            TaskResponse<List<GetRawMaterialDto>> response = new TaskResponse<List<GetRawMaterialDto>>();
            List<GetRawMaterialDto> rmDtos = new List<GetRawMaterialDto>();

            List<SuplierRawMaterial> srms = await _supplierRawMaterialRepo.GetQueryable()
                .Include(srm => srm.RawMaterial)
                .Where(srm => srm.RawMaterial.Active == 1 && srm.SuplierId == supplierId)
                .ToListAsync();

            foreach (SuplierRawMaterial srm in srms)
            {
                GetRawMaterialDto rmDto = _mapper.Map<GetRawMaterialDto>(srm.RawMaterial);
                rmDtos.Add(rmDto);
            }

            response.Data = rmDtos;
            return response;
        }

        public async Task<TaskResponse<List<GetSupplierDto>>> GetSupplierByRawMaterialId(short rawMaterialId)
        {
            TaskResponse<List<GetSupplierDto>> response = new TaskResponse<List<GetSupplierDto>>();
            List<GetSupplierDto> results = new List<GetSupplierDto>();

            List<SuplierRawMaterial> srms = await _supplierRawMaterialRepo.GetQueryable()
                .Include(srm => srm.Suplier)
                .Where(srm => srm.Suplier.Active == 1 && srm.RawMaterialId == rawMaterialId)
                .ToListAsync();

            foreach (SuplierRawMaterial srm in srms)
            {
                GetSupplierDto supplierDto = _mapper.Map<GetSupplierDto>(srm.Suplier);

                List<Qualification> qualifications = await _qualificationRepo.GetQueryable().Where(q => q.SuplierId == srm.SuplierId && q.Active == 1).ToListAsync();
                supplierDto.Qualification = qualifications.Select(q => _mapper.Map<GetQualificationDto>(q)).ToList();

                results.Add(supplierDto);
            }

            response.Data = results;
            return response;
        }
    }
}