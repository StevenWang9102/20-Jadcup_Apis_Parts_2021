using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.ParameterModel;

namespace Jadcup.Services.Interface.ParameterService
{
    public interface IParameterManagementService
    {
         Task<TaskResponse<List<GetParameterDto>>> Getall();
         Task<TaskResponse<string>> GetPoNumber();
    }
}