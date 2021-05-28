using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.AssessmentService;
using Jadcup.Services.Model.AssessmentModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.AssessmentService
{
    public class AssessmentService : IAssessmentService
    {
        private readonly IGenericMySqlAccessRepository<AccessmentStandards> _assessmentStandardRepo;
        private readonly IGenericMySqlAccessRepository<AccessmentStandardsDetail> _assessmentStandardDetailsRepo;
        private readonly IGenericMySqlAccessRepository<AccessmentPlan> _assessmentPlanRepo;
        private readonly IGenericMySqlAccessRepository<Accessment> _assessmentRepo;
        private readonly IGenericMySqlAccessRepository<AccessmentDetail> _assessmentDetailsRepo;
        
        private readonly IMapper _mapper;

        public AssessmentService(
            IGenericMySqlAccessRepository<AccessmentStandards> assessmentStandardRepo,
            IGenericMySqlAccessRepository<AccessmentStandardsDetail> assessmentStandardDetailsRepo,
            IGenericMySqlAccessRepository<AccessmentPlan> assessmentPlanRepo,
            IGenericMySqlAccessRepository<Accessment> assessmentRepo,
            IGenericMySqlAccessRepository<AccessmentDetail> assessmentDetailsRepo,
            IMapper mapper)
        {
            _mapper = mapper;
            _assessmentStandardRepo = assessmentStandardRepo;
            _assessmentStandardDetailsRepo = assessmentStandardDetailsRepo;
            _assessmentPlanRepo = assessmentPlanRepo;
            _assessmentRepo = assessmentRepo;
            _assessmentDetailsRepo = assessmentDetailsRepo;

            
        }

        // ------------------------------------------ Standard ------------------------------------------
        public async Task<TaskResponse<List<GetAllAssessmentStandardDto>>> GetAllAssessmentStandard()
        {
            TaskResponse<List<GetAllAssessmentStandardDto>> response = new TaskResponse<List<GetAllAssessmentStandardDto>>();

            List<AccessmentStandards> standards = await _assessmentStandardRepo.GetQueryable().ToListAsync();

            response.Data = standards.Select(c => _mapper.Map<GetAllAssessmentStandardDto>(c)).ToList();
            return response;
        }

        public async Task<TaskResponse<AccessmentStandards>> AddAssessmentStandard(AddStandardDto request)
        {
            TaskResponse<AccessmentStandards> response = new TaskResponse<AccessmentStandards>();

            String id = Guid.NewGuid().ToString();

            request.AcceStandardId = id;

            AccessmentStandards newStandard = _mapper.Map<AccessmentStandards>(request);

            _assessmentStandardRepo.Insert(newStandard);
            await _assessmentStandardRepo.SaveAsync();

            response.Data = newStandard;
            return response;
        }


        public async Task<TaskResponse<bool>> Update(UpdateStandardDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            AccessmentStandards dbTarget = await _assessmentStandardRepo.GetAsync(request.AcceStandardId);

            _mapper.Map(request, dbTarget);
            _assessmentStandardRepo.UpdateT(dbTarget);

            await _assessmentStandardRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> DeleteAssessmentStandard(string id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            AccessmentStandards targetEntity = await _assessmentStandardRepo.GetAsync(id);

            if (targetEntity == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _assessmentStandardRepo.Delete(targetEntity);
            await _assessmentStandardRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        // ------------------------------------------ Standard Details ------------------------------------------
        public async Task<TaskResponse<List<GetAllAssessmentStandardDetailsDto>>> GetAllAssessmentStandardDetails()
        {
            TaskResponse<List<GetAllAssessmentStandardDetailsDto>> response = new TaskResponse<List<GetAllAssessmentStandardDetailsDto>>();

            List<AccessmentStandardsDetail> standards = await _assessmentStandardDetailsRepo.GetQueryable().ToListAsync();

            response.Data = standards.Select(c => _mapper.Map<GetAllAssessmentStandardDetailsDto>(c)).ToList();
            return response;
        }

        public async Task<TaskResponse<AccessmentStandardsDetail>> AddAssessmentStandardDetails(AddStandardDetailsDto request)
        {
            TaskResponse<AccessmentStandardsDetail> response = new TaskResponse<AccessmentStandardsDetail>();

            var id = Guid.NewGuid().ToString();

            request.AcceStandDetailId = id;


            AccessmentStandardsDetail newStandard = _mapper.Map<AccessmentStandardsDetail>(request);

            _assessmentStandardDetailsRepo.Insert(newStandard);
            await _assessmentStandardDetailsRepo.SaveAsync();

            response.Data = newStandard;
            return response;
        }

        public async Task<TaskResponse<bool>> UpdateAssessmentStandardDetails(UpdateStandardDetailsDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            AccessmentStandardsDetail dbTarget = await _assessmentStandardDetailsRepo.GetAsync(request.AcceStandDetailId);

            _mapper.Map(request, dbTarget);
            _assessmentStandardDetailsRepo.UpdateT(dbTarget);

            await _assessmentStandardDetailsRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        
        public async Task<TaskResponse<bool>> DeleteAssessmentStandardDetails(string id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            AccessmentStandardsDetail targetEntity = await _assessmentStandardDetailsRepo.GetAsync(id);

            if (targetEntity == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _assessmentStandardDetailsRepo.Delete(targetEntity);
            await _assessmentStandardDetailsRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        // ------------------------------------------ Assessment Plan ------------------------------------------
        public async Task<TaskResponse<List<AssessmentPlanDto>>> GetAllAssessmentPlan()
        {
            TaskResponse<List<AssessmentPlanDto>> response = new TaskResponse<List<AssessmentPlanDto>>();

            List<AccessmentPlan> standards = await _assessmentPlanRepo.GetQueryable()
                .OrderByDescending(o => o.CreatedAt.ToString())
                .ToListAsync();

            response.Data = standards.Select(c => _mapper.Map<AssessmentPlanDto>(c)).ToList();
            return response;
        }

        public async Task<TaskResponse<AccessmentPlan>> AddAssessmentPlan(AddAssessmentPlanDto request)
        {
            TaskResponse<AccessmentPlan> response = new TaskResponse<AccessmentPlan>();

            var id = Guid.NewGuid().ToString();

            request.AccessmentPlanId = id;
            request.Active = 1;
            request.CreatedAt = DateTime.Now;

            AccessmentPlan newEntity = _mapper.Map<AccessmentPlan>(request);

            _assessmentPlanRepo.Insert(newEntity);
            await _assessmentPlanRepo.SaveAsync();

            response.Data = newEntity;
            return response;
        }


        public async Task<TaskResponse<bool>> UpdateAssessmentPlan(UpdateAssessmentPlanDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            AccessmentPlan dbTarget = await _assessmentPlanRepo.GetAsync(request.AccessmentPlanId);

            _mapper.Map(request, dbTarget);
            _assessmentPlanRepo.UpdateT(dbTarget);

            await _assessmentPlanRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> DeleteAssessmentPlan(string id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            AccessmentPlan targetEntity = await _assessmentPlanRepo.GetAsync(id);

            if (targetEntity == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _assessmentPlanRepo.Delete(targetEntity);
            await _assessmentPlanRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        // ------------------------------------------ Assessment (Released) ------------------------------------------
        public async Task<TaskResponse<List<AccessmentDto>>> GetOneAssessment(string? id)
        {
            TaskResponse<List<AccessmentDto>> response = new TaskResponse<List<AccessmentDto>>();

            List<Accessment> standards = await _assessmentRepo.GetQueryable()
                .Include(c => c.Employee)
                .Include(c => c.AccessmentPlan)
                .Include(c => c.AcceStandard)
                .Where(c => id == null ? true : c.AccessmentPlanId == id)
                .ToListAsync();

            response.Data = standards.Select(c => _mapper.Map<AccessmentDto>(c)).ToList();
            return response;
        }

        public async Task<TaskResponse<Accessment>> AddOneAssessment(AddOneAssessmentDto request)
        {
            TaskResponse<Accessment> response = new TaskResponse<Accessment>();

            var id = Guid.NewGuid().ToString();

            request.AccessmentId = id;
            request.Status = 0;
            request.TotalMarks = 0;
            request.Active = 1;

            Accessment newEntity = _mapper.Map<Accessment>(request);

            _assessmentRepo.Insert(newEntity);
            await _assessmentRepo.SaveAsync();

            response.Data = newEntity;
            return response;
        }

        public async Task<TaskResponse<bool>> UpdateOneAssessment(UpdateOneAssessmentDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Accessment dbTarget = await _assessmentRepo.GetAsync(request.AccessmentId);

            _mapper.Map(request, dbTarget);
            _assessmentRepo.UpdateT(dbTarget);

            await _assessmentRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> DeleteOneAssessment(string id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Accessment targetEntity = await _assessmentRepo.GetAsync(id);

            if (targetEntity == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _assessmentRepo.Delete(targetEntity);
            await _assessmentRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        // ------------------------------------------ Assessment Details ------------------------------------------
        public async Task<TaskResponse<List<AccessmentDetailsDto>>> GetAssessmentDetails()
        {
            TaskResponse<List<AccessmentDetailsDto>> response = new TaskResponse<List<AccessmentDetailsDto>>();

            List<AccessmentDetail> standards = await _assessmentDetailsRepo.GetQueryable()
                .Include(c => c.Accessment)
                .Include(c => c.AcceStandDetail)
                .ToListAsync();

            response.Data = standards.Select(c => _mapper.Map<AccessmentDetailsDto>(c)).ToList();
            return response;
        }

        public async Task<TaskResponse<AccessmentDetail>> AddAssessmentDetails(AddAssessmentDetailsDto request)
        {
            TaskResponse<AccessmentDetail> response = new TaskResponse<AccessmentDetail>();

            var id = Guid.NewGuid().ToString();

            request.AccessmentDetailId = id;
            request.CreatedAt = DateTime.Now;


            AccessmentDetail newEntity = _mapper.Map<AccessmentDetail>(request);

            _assessmentDetailsRepo.Insert(newEntity);
            await _assessmentDetailsRepo.SaveAsync();

            response.Data = newEntity;
            return response;
        }


        public async Task<TaskResponse<bool>> UpdateAssessmentDetails(UpdateAssessmentDetailDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            AccessmentDetail dbTarget = await _assessmentDetailsRepo.GetAsync(request.AccessmentDetailId);

            _mapper.Map(request, dbTarget);
            _assessmentDetailsRepo.UpdateT(dbTarget);

            await _assessmentDetailsRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> DeleteOneAssessmentDetails(string id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            AccessmentDetail targetEntity = await _assessmentDetailsRepo.GetAsync(id);

            if (targetEntity == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _assessmentDetailsRepo.Delete(targetEntity);
            await _assessmentDetailsRepo.SaveAsync();

            response.Data = true;
            return response;
        }
    }
}
