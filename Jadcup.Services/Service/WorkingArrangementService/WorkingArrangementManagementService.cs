using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.WorkingArrangementService;
using Jadcup.Services.Model.WorkingArrangementModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.WorkingArrangementService
{
    public class WorkingArrangementManagementService : IWorkingArrangementManagementService
    {
        private readonly IGenericMySqlAccessRepository<WorkingArrangement> _workingArrangementRepo;
        private readonly IMapper _mapper;

        public WorkingArrangementManagementService(IGenericMySqlAccessRepository<WorkingArrangement> workingArrangementRepo, IMapper mapper)
        {
            _mapper = mapper;
            _workingArrangementRepo = workingArrangementRepo;

        }
        public async Task<TaskResponse<int>> Add(AddWorkingArrangementDto request)
        {
            TaskResponse<int> response = new TaskResponse<int>();

            WorkingArrangement wa = _mapper.Map<WorkingArrangement>(request);
            wa.CreatedAt = DateTime.UtcNow;

            _workingArrangementRepo.Insert(wa);
            await _workingArrangementRepo.SaveAsync();

            response.Data = wa.ArrangementId;
            return response;
        }

        public async Task<TaskResponse<bool>> AddList(List<AddWorkingArrangementDto> request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            foreach (AddWorkingArrangementDto re in request)
            {
                WorkingArrangement wa = _mapper.Map<WorkingArrangement>(re);
                wa.CreatedAt = DateTime.UtcNow;

                _workingArrangementRepo.Insert(wa);
            }

            await _workingArrangementRepo.SaveAsync();
            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> Delete(int id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            WorkingArrangement wa = await _workingArrangementRepo.GetAsync(id);

            if (wa == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _workingArrangementRepo.Delete(wa);
            await _workingArrangementRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> DeleteList(List<int> request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            foreach (int id in request)
            {
                WorkingArrangement wa = await _workingArrangementRepo.GetAsync(id);
                _workingArrangementRepo.Delete(wa);
            }

            await _workingArrangementRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetWorkingArrangementDto>>> GetAll(int? createdBy, DateTime? workingDate, short? machingId, int? operatorId, DateTime? start, DateTime? end)
        {
            TaskResponse<List<GetWorkingArrangementDto>> response = new TaskResponse<List<GetWorkingArrangementDto>>();

            List<WorkingArrangement> was = await _workingArrangementRepo.GetQueryable()
                .Where(w => createdBy == null || w.CreatedBy == createdBy)
                .Where(w => workingDate == null || w.WorkingDate == workingDate)
                .Where(w => machingId == null || w.MachineId == machingId)
                .Where(w => operatorId == null || w.Operator == operatorId)
                .Where(w => start == null || w.WorkingDate >= start)
                .Where(w => end == null || w.WorkingDate <= end)
                .Include(w => w.CreatedByNavigation)
                .Include(w => w.Machine)
                .Include(w => w.OperatorNavigation)
                .ToListAsync();

            response.Data = was.Select(w => _mapper.Map<GetWorkingArrangementDto>(w)).ToList();
            return response;
        }

        public async Task<TaskResponse<GetWorkingArrangementDto>> GetById(int id)
        {
            TaskResponse<GetWorkingArrangementDto> response = new TaskResponse<GetWorkingArrangementDto>();

            WorkingArrangement wa = await _workingArrangementRepo.GetQueryable()
                .Include(w => w.CreatedByNavigation)
                .Include(w => w.Machine)
                .Include(w => w.OperatorNavigation)
                .FirstOrDefaultAsync(w => w.ArrangementId == id);

            if (wa == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            response.Data = _mapper.Map<GetWorkingArrangementDto>(wa);
            return response;
        }

        public async Task<TaskResponse<bool>> Update(UpdateWorkingArrangementDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            WorkingArrangement wa = await _workingArrangementRepo.GetAsync(request.ArrangementId);
            if (wa == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _mapper.Map(request, wa);
            _workingArrangementRepo.UpdateT(wa);
            await _workingArrangementRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> UpdateList(List<UpdateWorkingArrangementDto> request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            foreach (UpdateWorkingArrangementDto re in request)
            {
                WorkingArrangement wa = await _workingArrangementRepo.GetAsync(re.ArrangementId);

                _mapper.Map(re, wa);
                _workingArrangementRepo.UpdateT(wa);
            }

            await _workingArrangementRepo.SaveAsync();

            response.Data = true;
            return response;
        }
    }
}