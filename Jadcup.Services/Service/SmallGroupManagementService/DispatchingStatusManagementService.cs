using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.DispatchingStatusModel;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class DispatchingStatusManagementService : IDispatchingStatusManagementService
    {
        private readonly IGenericMySqlAccessRepository<DispatchingStatus> _dispatchingStatusRepo;
        private readonly IMapper _mapper;
        public DispatchingStatusManagementService(IGenericMySqlAccessRepository<DispatchingStatus> dispatchingStatusRepo, IMapper mapper)
        {
            _mapper = mapper;
            _dispatchingStatusRepo = dispatchingStatusRepo;

        }
        public async Task<TaskResponse<List<GetDispatchingStatusDto>>> GetAll()
        {
            TaskResponse<List<GetDispatchingStatusDto>> response = new TaskResponse<List<GetDispatchingStatusDto>>();

            List<DispatchingStatus> ds = await _dispatchingStatusRepo.GetAllAsync();

            response.Data = ds.Select(d => _mapper.Map<GetDispatchingStatusDto>(d)).ToList();
            return response;
        }
    }
}