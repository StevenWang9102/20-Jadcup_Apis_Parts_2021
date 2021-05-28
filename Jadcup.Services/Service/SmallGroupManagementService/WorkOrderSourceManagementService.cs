using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.WorkOrderSourceModel;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class WorkOrderSourceManagementService : IWorkOrderSourceManagementService
    {
        private readonly IMapper _mapper;
        private readonly IGenericMySqlAccessRepository<WorkOrderSource> _workOrderSourceRepo;
        public WorkOrderSourceManagementService(IMapper mapper, IGenericMySqlAccessRepository<WorkOrderSource> workOrderSourceRepo)
        {
            _workOrderSourceRepo = workOrderSourceRepo;
            _mapper = mapper;

        }
        public async Task<TaskResponse<List<GetWorkOrderSourceDto>>> GetAll()
        {
            TaskResponse<List<GetWorkOrderSourceDto>> response = new TaskResponse<List<GetWorkOrderSourceDto>>();

            List<WorkOrderSource> ots = await _workOrderSourceRepo.GetAllAsync();

            response.Data = ots.Select(o => _mapper.Map<GetWorkOrderSourceDto>(o)).ToList();
            return response;
        }
    }
}