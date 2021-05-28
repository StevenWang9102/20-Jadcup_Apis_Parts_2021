using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.RecordTypeModel;

namespace Jadcup.Services.Interface.RecordTypeService
{
    public interface IRecordTypeService
    {
        Task<TaskResponse<List<GetRecordTypeDto>>> GetAll();
    }
}