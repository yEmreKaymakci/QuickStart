using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBakery.WepApi.Context;
using MyBakery.WepApi.Entity;

namespace MyBakery.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly MyBakeryContext _context;

        public AboutController(MyBakeryContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult AboutList()
        {
            var value = _context.Abouts.ToList();
            return Ok(value);
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = _context.Abouts.Find(id);
            return Ok(value);
        }
        [HttpPost]

        public IActionResult CreateAbout(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return Ok("ekleme işlemi başarı ile gerçekleşti");
        }
        [HttpPut]

        public IActionResult UpdateAbout(About about)
        {
            _context.Abouts.Update(about);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }
        [HttpDelete]

        public IActionResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            _context.Abouts.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}
