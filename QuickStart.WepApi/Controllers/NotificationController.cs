using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.Dto;
using QuickStart.WepApi.Entity;

namespace QuickStart.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public NotificationController(QuickStartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetNotificationList()
        {
            var values = _context.Notifications.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetNotificationById(int id)
        {
            var value = _context.Notifications
                .Include(x => x.NotificationType)
                .Where(x => x.NotificationId == id)
                .Select(x => new ResultNotificationWithNotificationTypeDto
                {
                    NotificationId = x.NotificationId,
                    Title = x.Title,
                    Content = x.Content,
                    IsRead = x.IsRead,
                    Email = x.Email,
                    NotificationTypeName = x.NotificationType.Name
                })
                .FirstOrDefault();

            if (value == null)
                return NotFound();

            return Ok(value);
        }

        [HttpGet("GetNotificationListWithNotificationType")]
        public IActionResult NotificationList()
        {
            var values = _context.Notifications
                .Include(x => x.NotificationType)
                .Select(x => new ResultNotificationWithNotificationTypeDto
                {
                    NotificationId = x.NotificationId,
                    Title = x.Title,
                    Content = x.Content,
                    IsRead = x.IsRead,
                    Email = x.Email,
                    NotificationTypeName = x.NotificationType.Name
                });
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto dto)
        {
            var notificationType = _context.NotificationTypes
                .FirstOrDefault(x => x.Name == dto.NotificationTypeName);

            if (notificationType == null)
                return BadRequest($"'{dto.NotificationTypeName}' adında bir bildirim türü bulunamadı.");

            var notification = new Notification
            {
                Title = dto.Title,
                Content = dto.Content,
                IsRead = dto.IsRead,
                Email = dto.Email,
                NotificationTypeId = notificationType.NotificationTypeId
            };

            _context.Notifications.Add(notification);
            _context.SaveChanges();
            return Ok("Bildirim başarıyla oluşturuldu.");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto dto)
        {
            var notification = _context.Notifications.Find(dto.NotificationId);
            if (notification == null)
                return NotFound();

            var notificationType = _context.NotificationTypes
                .FirstOrDefault(x => x.Name == dto.NotificationTypeName);

            if (notificationType == null)
                return BadRequest($"'{dto.NotificationTypeName}' adında bir bildirim türü bulunamadı.");

            notification.Title = dto.Title;
            notification.Content = dto.Content;
            notification.IsRead = dto.IsRead;
            notification.Email = dto.Email;
            notification.NotificationTypeId = notificationType.NotificationTypeId;

            _context.SaveChanges();
            return Ok("Bildirim başarıyla güncellendi.");
        }

        [HttpDelete]
        public IActionResult DeleteNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            if (value == null)
                return NotFound();

            _context.Notifications.Remove(value);
            _context.SaveChanges();
            return Ok("Bildirim başarıyla silindi.");
        }

        [HttpGet("MarkeAsRead/{id}")]
        public IActionResult MarkAsRead(int id)
        {
            var value = _context.Notifications.Find(id);
            if (value == null)
                return NotFound();

            value.IsRead = true;
            _context.SaveChanges();
            return Ok("Bildirim okundu olarak işaretlendi.");
        }
    }
}
