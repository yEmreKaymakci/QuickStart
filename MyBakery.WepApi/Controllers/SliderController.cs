using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBakery.WepApi.Context;
using MyBakery.WepApi.Entity;

namespace MyBakery.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly MyBakeryContext _context;

        public SliderController(MyBakeryContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult SliderList()
        {
            var value = _context.Sliders.ToList();
            return Ok(value);
        }
        [HttpGet("SliderCount")]

        public IActionResult SliderCount()
        {
            var value = _context.Sliders.Count();
            return Ok(value);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = _context.Sliders.Find(id);
            return Ok(value);
        }
        [HttpPost]

        public IActionResult CreateSlider(Slider slider)
        {
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }
        [HttpPut]

        public IActionResult UpdateSlider(Slider slider)
        {
            _context.Sliders.Update(slider);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }
        [HttpDelete]

        public IActionResult DeleteSlider(int id)
        {
            var value = _context.Sliders.Find(id);
            _context.Sliders.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}
