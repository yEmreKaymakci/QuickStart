using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBakery.WepApi.Context;
using MyBakery.WepApi.Entity;

namespace MyBakery.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly MyBakeryContext _context;

        public FeatureController(MyBakeryContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult FeatureList()
        {
            var value = _context.Features.ToList();
            return Ok(value);
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = _context.Features.Find(id);
            return Ok(value);
        }
        [HttpPost]

        public IActionResult CreateFeature(Feature feature)
        {
            _context.Features.Add(feature);
            _context.SaveChanges();
            return Ok("ekleme işlemi başarı ile gerçekleşti");
        }
        [HttpPut]

        public IActionResult UpdateFeature(Feature feature)
        {
            _context.Features.Update(feature);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }
        [HttpDelete]

        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");

        }
    }
}
