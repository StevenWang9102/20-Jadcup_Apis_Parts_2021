using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SupplierService;
using Jadcup.Services.Model.QualificationModel;
using Jadcup.Services.Model.SupplierModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.SupplierService
{
    public class SupplierManagementService : ISupplierManagementService
    {
        private readonly IGenericMySqlAccessRepository<Suplier> _supplierRepo;
        private readonly IGenericMySqlAccessRepository<Qualification> _qualificationRepo;
        private readonly IMapper _mapper;
        public SupplierManagementService(IGenericMySqlAccessRepository<Suplier> supplierRepo, IGenericMySqlAccessRepository<Qualification> qualificationRepo, IMapper mapper)
        {
            _mapper = mapper;
            _qualificationRepo = qualificationRepo;
            _supplierRepo = supplierRepo;

        }
        public async Task<TaskResponse<short>> Add(AddSupplierDto request)
        {
            TaskResponse<short> response = new TaskResponse<short>();

            if (await _supplierRepo.GetQueryable().AnyAsync(s => s.SuplierName == request.SuplierName && s.SuplierType == request.SuplierType))
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, SystemMessage.DuplicateError());
            }

            Suplier supplier = _mapper.Map<Suplier>(request);
            supplier.Active = 1;

            _supplierRepo.Insert(supplier);
            await _supplierRepo.SaveAsync();

            response.Data = supplier.SuplierId;
            return response;
        }

        public async Task<TaskResponse<short>> AddFull(AddSupplierDto2 request)
        {
            TaskResponse<short> response = new TaskResponse<short>();

            if (await _supplierRepo.GetQueryable().AnyAsync(s => s.SuplierName == request.SuplierName && s.SuplierType == request.SuplierType))
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, SystemMessage.DuplicateError());
            }

            using var transaction = _supplierRepo.GetContext().Database.BeginTransaction();

            try
            {
                Suplier supplier = _mapper.Map<Suplier>(request);
                supplier.Active = 1;

                _supplierRepo.Insert(supplier);
                await _supplierRepo.SaveAsync();

                List<Qualification> qualifications = new List<Qualification>();

                foreach(AddQualificationDto qualificationDto in request.Qualification)
                {
                    Qualification qualification = _mapper.Map<Qualification>(qualificationDto);
                    qualification.Active = 1;
                    qualification.SuplierId = supplier.SuplierId;

                    qualifications.Add(qualification);
                }

                _qualificationRepo.InsertRange(qualifications);
                await _qualificationRepo.SaveAsync();

                transaction.Commit();
                response.Data = supplier.SuplierId;
                
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, new SystemMessage(ex.ToString()));
            }

            return response;
        }

        public async Task<TaskResponse<bool>> AddQualification(List<AddQualificationDto> request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            List<Qualification> qualifications = new List<Qualification>();

            foreach(AddQualificationDto dto in request)
            {
                Qualification qualification = _mapper.Map<Qualification>(dto);
                qualification.Active = 1;

                qualifications.Add(qualification);
            }

            _qualificationRepo.InsertRange(qualifications);
            await _qualificationRepo.SaveAsync();

            response.Data = true;
            return response;            
        }

        public async Task<TaskResponse<bool>> Delete(short id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Suplier supplier = await _supplierRepo.GetAsync(id);

            if (supplier == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            supplier.Active = 0;
            _supplierRepo.UpdateT(supplier);
            await _supplierRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> DeleteQualification(short id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Qualification qualification = await _qualificationRepo.GetAsync(id);

            if (qualification == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            qualification.Active = 0;

            _qualificationRepo.UpdateT(qualification);
            await _qualificationRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetSupplierDto>>> GetAll(ulong? active)
        {
            TaskResponse<List<GetSupplierDto>> response = new TaskResponse<List<GetSupplierDto>>();
            List<GetSupplierDto> result = new List<GetSupplierDto>();

            List<Suplier> suppliers = await _supplierRepo.GetQueryable().Where(s => s.Active == active || active == null).ToListAsync();
            List<Qualification> qualifications = await _qualificationRepo.GetQueryable().Where(q => q.Active == 1).ToListAsync();

            foreach(Suplier supplier in suppliers)
            {
                GetSupplierDto supplierDto = _mapper.Map<GetSupplierDto>(supplier);

                supplierDto.Qualification = qualifications.Where(q => q.SuplierId == supplier.SuplierId && q.Active == 1).ToList().Select(q => _mapper.Map<GetQualificationDto>(q)).ToList();

                result.Add(supplierDto);
            }

            response.Data = result;
            return response;
        }

        public async Task<TaskResponse<GetSupplierDto>> GetById(short id)
        {
            TaskResponse<GetSupplierDto> response = new TaskResponse<GetSupplierDto>();

            Suplier supplier = await _supplierRepo.GetAsync(id);
            if (supplier == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            GetSupplierDto supplierDto = _mapper.Map<GetSupplierDto>(supplier);

            List<Qualification> qualifications = await _qualificationRepo.GetQueryable().Where(q => q.SuplierId == id && q.Active == 1).ToListAsync();

            supplierDto.Qualification = qualifications.Select(q => _mapper.Map<GetQualificationDto>(q)).ToList();

            response.Data = supplierDto;
            return response;
        }

        public async Task<TaskResponse<bool>> Update(UpdateSupplierDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Suplier supplier = await _supplierRepo.GetAsync(request.SuplierId);
            if (supplier == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _mapper.Map(request, supplier);
            _supplierRepo.UpdateT(supplier);
            await _supplierRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> UpdateQualification(UpdateQualificationDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Qualification qualification = await _qualificationRepo.GetAsync(request.QualificationId);
            if (qualification == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }


            _mapper.Map(request, qualification);
            _qualificationRepo.UpdateT(qualification);
            await _qualificationRepo.SaveAsync();

            response.Data = true;
            return response;
        }
    }
}