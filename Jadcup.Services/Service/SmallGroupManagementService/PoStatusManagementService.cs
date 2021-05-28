using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.PoStatusModel;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class PoStatusManagementService : IPoStatusManagementService
    {
        private readonly IGenericMySqlAccessRepository<PoStatus> _poStatusRepo;
        private readonly IMapper _mapper;
        public PoStatusManagementService(IGenericMySqlAccessRepository<PoStatus> poStatusRepo, IMapper mapper)
        {
            _mapper = mapper;
            _poStatusRepo = poStatusRepo;

        }
        public async Task<TaskResponse<List<GetPoStatusDto>>> GetAll()
        {
            TaskResponse<List<GetPoStatusDto>> response = new TaskResponse<List<GetPoStatusDto>>();

            List<PoStatus> poStatuses = await _poStatusRepo.GetAllAsync();

            response.Data = poStatuses.Select(p => _mapper.Map<GetPoStatusDto>(p)).ToList();
            return response;
        }
    }
}