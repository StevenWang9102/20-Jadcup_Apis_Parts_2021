using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Jadcup.Services.Interface.OnlineUserService;
using Jadcup.Services.Model.OnlineUserModel;

namespace Jadcup.Api.Controllers.OnlineUserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineUserController : Controller
    {
        private readonly IOlineUserManagementService _iOnlineUserManagementService;

        public OnlineUserController(IOlineUserManagementService iOnlineUserManagementService)
        {
            _iOnlineUserManagementService = iOnlineUserManagementService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> OnlineUserRegister(AddOnlineUserDto request)
        {
            return Ok(await _iOnlineUserManagementService.Add(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ChangeOnlineUserPassword(UpdateOnlineUserDto request)
        {
            return Ok(await _iOnlineUserManagementService.UpdatePassword(request));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> OnlineUserLogin(OnlineUserLoginDto request)
        {
            return Ok(await _iOnlineUserManagementService.Login(request));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> OnlineUserCheckPassword(OnlineUserLoginDto request)
        {
            return Ok(await _iOnlineUserManagementService.CheckPassword(request));
        }
    }
}
