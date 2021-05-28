using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Error;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.MachineService;
using Jadcup.Services.Model.MachineModel;
using Microsoft.EntityFrameworkCore;

namespace Jadcup.Services.Service.MachineService
{
    public class MachineManagementService : IMachineManagementService
    {
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<Machine> _machineRepo;
        public MachineManagementService(IMapper mapper, IGenericMySqlAccessRepository<Machine> machineRepo)
        {
            _machineRepo = machineRepo;
            _mapper = mapper;

        }
        public async Task<TaskResponse<bool>> Add(AddMachineDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            Machine machine = _mapper.Map<Machine>(request);
            machine.Status = 1;

            _machineRepo.Insert(machine);
            await _machineRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> Delete(short id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            Machine machine = await _machineRepo.GetQueryable().Where(m => m.Status == 1).FirstOrDefaultAsync(m => m.MachineId == id);
            if (machine == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            machine.Status = 0;
            _machineRepo.UpdateT(machine);
            await _machineRepo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<List<GetMachineDto>>> GetAll()
        {
            TaskResponse<List<GetMachineDto>> response = new TaskResponse<List<GetMachineDto>>();

            List<Machine> machines = await _machineRepo.GetQueryable().Where(m => m.Status == 1).Include(m => m.MachineType).ToListAsync();

            response.Data = machines.Select(m => _mapper.Map<GetMachineDto>(m)).ToList();

            return response;
        }

        public async Task<TaskResponse<GetMachineDto>> GetById(short id)
        {
            TaskResponse<GetMachineDto> response = new TaskResponse<GetMachineDto>();
            Machine machine = await _machineRepo.GetQueryable().Where(m => m.Status == 1).Include(m => m.MachineType).FirstOrDefaultAsync(m => m.MachineId == id);
            if (machine == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            response.Data = _mapper.Map<GetMachineDto>(machine);
            return response;
        }

        public async Task<TaskResponse<bool>> Update(UpdateMachineDto request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();
            Machine machine = await _machineRepo.GetQueryable().Where(m => m.Status == 1).FirstOrDefaultAsync(m => m.MachineId == request.MachineId);
            if (machine == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _mapper.Map(request, machine);
            _machineRepo.UpdateT(machine);
            await _machineRepo.SaveAsync();

            response.Data = true;
            return response;
        }
    }
}