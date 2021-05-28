using Jadcup.Common.Repository;
using Jadcup.Services.Interface.SalesVisitService;
using System;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jadcup.Common.Model;
using Jadcup.Services.Model.SalesVistModel;
using Jadcup.Common.Context;
using Microsoft.EntityFrameworkCore;
using Jadcup.Common.Error;
using Jadcup.Services.Interface.NotificationService;
using Jadcup.Services.Model.NotificationModal;
using Jadcup.Services.Model.NotificationModel;

namespace Jadcup.Services.Service.NotificationService
{
    public class NotificationService: INotificationService
    {
        private readonly IGenericMySqlAccessRepository<Notification> _notification_repo;
        private readonly IMapper _mapper;
        public NotificationService(IGenericMySqlAccessRepository<Notification> notification_repo, IMapper mapper)
        {
            _mapper = mapper;
            _notification_repo = notification_repo;
        }
        
        public async Task<TaskResponse<short>> Add(AddNotificationDto request)
        {
            TaskResponse<short> response = new TaskResponse<short>();

            request.IsActive = true;
            Notification newNotification = _mapper.Map<Notification>(request);
            _notification_repo.Insert(newNotification);
            await _notification_repo.SaveAsync();

            return response;
        }


        public async Task<TaskResponse<List<GetNotificationDto>>> GetAll()
        {
            TaskResponse<List<GetNotificationDto>> response = new TaskResponse<List<GetNotificationDto>>();

            List<Notification> entities = await _notification_repo.GetQueryable()
                .Include(c => c.Role).Include(c =>c.Creater)
                .ToListAsync();

            response.Data = entities.Select(c => _mapper.Map<GetNotificationDto>(c)).ToList();
            return response;
        }

        public async Task<TaskResponse<List<GetNotificationDto>>> GetByRole(short roleId)
        {
            TaskResponse<List<GetNotificationDto>> response = new TaskResponse<List<GetNotificationDto>>();

            List<Notification> entities = await _notification_repo.GetQueryable()
                .Include(c => c.Role).Include(c =>c.Creater)
                .Where(c => c.RoleId == roleId && c.IsActive == true &&
                (c.StartDate.Date >= DateTime.UtcNow.Date && c.EndDate.Date <=DateTime.UtcNow.Date))
                .ToListAsync();

            response.Data = entities.Select(c => _mapper.Map<GetNotificationDto>(c)).ToList();
            return response;
        }


        public async Task<TaskResponse<GetNotificationDto>> GetById(int id)
        {
            TaskResponse<GetNotificationDto> response = new TaskResponse<GetNotificationDto>();

            Notification entities = await _notification_repo.GetQueryable()
                .Include(c => c.Role).Include(c =>c.Creater)
                .FirstOrDefaultAsync(c => c.NotificationId == id);

            response.Data = _mapper.Map<GetNotificationDto>(entities);
            return response;
        }

        public async Task<TaskResponse<bool>> Update(UpdateNotification request)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            // Search
            Notification targetObj = await _notification_repo.GetAsync(request.NotificationId);

            // Change
            _mapper.Map(request, targetObj);
            _notification_repo.UpdateT(targetObj);

            // Save
            await _notification_repo.SaveAsync();

            response.Data = true;
            return response;
        }

        public async Task<TaskResponse<bool>> Delete(int id)
        {
            TaskResponse<bool> response = new TaskResponse<bool>();

            Notification targetObj = await _notification_repo.GetAsync(id);

            if (targetObj == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound, SystemMessage.ItemNotFound());
            }

            _notification_repo.Delete(targetObj);
            await _notification_repo.SaveAsync();

            response.Data = true;
            return response;
        }
    }
}
