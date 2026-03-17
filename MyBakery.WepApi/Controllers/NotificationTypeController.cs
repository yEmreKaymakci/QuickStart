using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBakery.WepApi.Context;
using MyBakery.WepApi.Entity;

namespace MyBakery.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationTypeController : ControllerBase
    {
        private readonly MyBakeryContext _context;

        public NotificationTypeController(MyBakeryContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult NotificationTypeList()
        {
            var value = _context.NotificationTypes.ToList();
            return Ok(value);
        }
        [HttpGet("NotificationTypeCount")]

        public IActionResult NotificationTypeCount()
        {
            var value = _context.NotificationTypes.Count();
            return Ok(value);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = _context.NotificationTypes.Find(id);
            return Ok(value);
        }
        [HttpPost]

        public IActionResult CreateNotificationType(NotificationType notificationType)
        {
            _context.NotificationTypes.Add(notificationType);
            _context.SaveChanges();
            return Ok("ekleme işlemi başarı ile gerçekleşti");
        }
        [HttpPut]

        public IActionResult UpdateNotificationType(NotificationType notificationType)
        {
            _context.NotificationTypes.Update(notificationType);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }
        [HttpDelete]

        public IActionResult DeleteNotificationType(int id)
        {
            var value = _context.NotificationTypes.Find(id);
            _context.NotificationTypes.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}
