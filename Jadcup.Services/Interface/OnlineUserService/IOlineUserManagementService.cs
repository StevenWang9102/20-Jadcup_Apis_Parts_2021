using Jadcup.Common.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Jadcup.Services.Model.OnlineUserModel;

namespace Jadcup.Services.Interface.OnlineUserService
{
    public interface IOlineUserManagementService
    {
        Task<TaskResponse<int>> Add(AddOnlineUserDto request);
        Task<TaskResponse<bool>> UpdatePassword(UpdateOnlineUserDto request);
        Task<TaskResponse<OnlineUserLoginResultDto>> Login(OnlineUserLoginDto request);
        Task<TaskResponse<bool>> CheckPassword(OnlineUserLoginDto request);
    }
}
