using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SuborderStatusService;
using Jadcup.Services.Model.SuborderStatusModel;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class SuborderStatusManagementService : ISuborderStatusManagementService
    {
        private readonly IGenericMySqlAccessRepository<SuborderStatus> _suborderStatusRepo;
        private readonly IMapper _mapper;
        public SuborderStatusManagementService(IGenericMySqlAccessRepository<SuborderStatus> suborderStatusRepo, IMapper mapper)
        {
            _mapper = mapper;
            _suborderStatusRepo = suborderStatusRepo;

        }
        public async Task<TaskResponse<List<GetSuborderStatusDto>>> GetAll()
        {
            TaskResponse<List<GetSuborderStatusDto>> response = new TaskResponse<List<GetSuborderStatusDto>>();

            List<SuborderStatus> ss = await _suborderStatusRepo.GetAllAsync();

            response.Data = ss.Select(s => _mapper.Map<GetSuborderStatusDto>(s)).ToList();

            return response;
        }
    }
}