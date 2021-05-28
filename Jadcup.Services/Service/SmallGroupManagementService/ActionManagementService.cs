using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jadcup.Common.Context;
using Jadcup.Common.Model;
using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SmallGroupManagementInterface;
using Jadcup.Services.Model.ActionModel;

namespace Jadcup.Services.Service.SmallGroupManagementService
{
    public class ActionManagementService : IActionManagementService
    {
        private readonly IGenericMySqlAccessRepository<Action> _actionRepo;
        private readonly IMapper _mapper;
        public ActionManagementService(IMapper mapper, IGenericMySqlAccessRepository<Action> actionRepo)
        {
            _mapper = mapper;
            _actionRepo = actionRepo;

        }
        public async Task<TaskResponse<List<GetActionDto>>> GetAll()
        {
            TaskResponse<List<GetActionDto>> response = new TaskResponse<List<GetActionDto>>();

            List<Action> actions = await _actionRepo.GetAllAsync();

            response.Data = actions.Select(a => _mapper.Map<GetActionDto>(a)).ToList();
            return response;
        }
    }
}