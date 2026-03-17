using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBakery.WepApi.Context;
using MyBakery.WepApi.Entity;

namespace MyBakery.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureServiceController : ControllerBase
    {
        private readonly MyBakeryContext _context;

        public FeatureServiceController(MyBakeryContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult FeatureServiceList()
        {
            var value = _context.FeatureServices.ToList();
            return Ok(value);
        }
        [HttpGet("FeatureServiceCount")]

        public IActionResult FeatureServiceCount()
        {
            var value = _context.FeatureServices.Count();
            return Ok(value);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = _context.FeatureServices.Find(id);
            return Ok(value);
        }
        [HttpPost]

        public IActionResult CreateFeatureService(FeatureService featureService)
        {
            _context.FeatureServices.Add(featureService);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }
        [HttpPut]

        public IActionResult UpdateFeatureService(FeatureService featureService)
        {
            _context.FeatureServices.Update(featureService);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }
        [HttpDelete]

        public IActionResult DeleteFeatureService(int id)
        {
            var value = _context.FeatureServices.Find(id);
            _context.FeatureServices.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}
