using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBakery.WepApi.Context;
using MyBakery.WepApi.Entity;

namespace MyBakery.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly MyBakeryContext _context;

        public ClientController(MyBakeryContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult ClientList()
        {
            var value = _context.Clients.ToList();
            return Ok(value);
        }
        [HttpGet("ClientCount")]

        public IActionResult ClientCount()
        {
            var value = _context.Clients.Count();
            return Ok(value);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = _context.Clients.Find(id);
            return Ok(value);
        }
        [HttpPost]

        public IActionResult CreateClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }
        [HttpPut]

        public IActionResult UpdateClient(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }
        [HttpDelete]

        public IActionResult DeleteClient(int id)
        {
            var value = _context.Clients.Find(id);
            _context.Clients.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}
