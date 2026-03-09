using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStart.WepApi.Context;
using QuickStart.WepApi.Entity;

namespace QuickStart.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly QuickStartContext _context;

        public SubscribeController(QuickStartContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult SubscribeList()
        {
            var value = _context.Subscribes.ToList();
            return Ok(value);
        }
        [HttpGet("SubscribeCount")]

        public IActionResult SubscribeCount()
        {
            var value = _context.Subscribes.Count();
            return Ok(value);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = _context.Subscribes.Find(id);
            return Ok(value);
        }
        [HttpPost]

        public IActionResult CreateSubscribe(Subscribe subscribe)
        {
            _context.Subscribes.Add(subscribe);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }
        [HttpPut]

        public IActionResult UpdateSubscribe(Subscribe subscribe)
        {
            _context.Subscribes.Update(subscribe);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }
        [HttpDelete]

        public IActionResult DeleteSubscribe(int id)
        {
            var value = _context.Subscribes.Find(id);
            _context.Subscribes.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}
