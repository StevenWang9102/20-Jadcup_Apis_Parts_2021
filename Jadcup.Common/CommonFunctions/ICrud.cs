using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;

namespace Jadcup.Common.CommonFunctions
{
    public interface ICrud<T, U, V>
    {
        Task<TaskResponse<bool>> AddToTableAsync(T t, object dto);
        Task<TaskResponse<bool>> DeleteFromTableAsync(object id);
        Task<TaskResponse<List<U>>> GetAll();
        Task<TaskResponse<U>> GetById(object id);
        Task<TaskResponse<U>> UpdateEntry(T t, V v, bool duplicated);
    }
}