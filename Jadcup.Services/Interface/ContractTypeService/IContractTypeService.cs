using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.BoxModel;
using Jadcup.Services.Model.ContractTypeModel;

namespace Jadcup.Services.Interface.ContractTypeService
{
    public interface IContractTypeService
    {
        Task<TaskResponse<List<GetContractTypeDto>>> GetAll( );
    }
}