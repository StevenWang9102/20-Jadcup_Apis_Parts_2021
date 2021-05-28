using Jadcup.Common.Model;
using Jadcup.Services.Model.NotificationModal;
using Jadcup.Services.Model.NotificationModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jadcup.Services.Interface.NotificationService
{
    public interface INotificationService
    {
        Task<TaskResponse<List<GetNotificationDto>>> GetAll();
        Task<TaskResponse<List<GetNotificationDto>>> GetByRole(short roleId);
        Task<TaskResponse<GetNotificationDto>> GetById(int id);
        Task<TaskResponse<short>> Add(AddNotificationDto request);
        Task<TaskResponse<bool>> Update(UpdateNotification request);
        Task<TaskResponse<bool>> Delete(int id);
    }
}
