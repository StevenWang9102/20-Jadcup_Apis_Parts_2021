using Jadcup.Services.Interface.NotificationService;
using Jadcup.Services.Model.NotificationModal;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jadcup.Api.Controllers.NotificationController
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService service)
        {
            _notificationService = service;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllNotification()
        {
            return Ok(await _notificationService.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByRole(short roleId)
        {
            return Ok(await _notificationService.GetByRole(roleId));
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddNotification(AddNotificationDto request)
        {
            return Ok(await _notificationService.Add(request));
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            return Ok(await _notificationService.GetById(id));
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateNotification(UpdateNotification request)
        {
            return Ok(await _notificationService.Update(request));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            return Ok(await _notificationService.Delete(id));
        }
    }
}
