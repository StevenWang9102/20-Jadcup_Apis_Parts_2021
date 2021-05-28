using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Services.Interface.WorkOrderStatusService;
using Jadcup.Services.Model.WorkOrderStatusModel;

namespace Jadcup.Services.Service.WorkOrderStatusService
{
    public class WorkOrderStatusManagementService : IWorkOrderStatusManagementService
    {
        private readonly IMapper _mapper;
        private readonly Common.Repository.IGenericMySqlAccessRepository<WorkOrderStatus> _workOrderStatusRepo;
        public WorkOrderStatusManagementService(IMapper mapper, Common.Repository.IGenericMySqlAccessRepository<WorkOrderStatus> workOrderStatusRepo)
        {
            _workOrderStatusRepo = workOrderStatusRepo;
            _mapper = mapper;

        }
        public async Task<TaskResponse<List<GetWorkOrderStatusDto>>> GetAll()
        {
            TaskResponse<List<GetWorkOrderStatusDto>> response = new TaskResponse<List<GetWorkOrderStatusDto>>();

            List<WorkOrderStatus> wos = await _workOrderStatusRepo.GetAllAsync();

            response.Data = wos.Select(w => _mapper.Map<GetWorkOrderStatusDto>(w)).ToList();
            return response;
        }
    }
}