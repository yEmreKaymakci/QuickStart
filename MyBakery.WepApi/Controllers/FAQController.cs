using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBakery.WepApi.Context;
using MyBakery.WepApi.Entity;

namespace MyBakery.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController : ControllerBase
    {
        private readonly MyBakeryContext _context;

        public FAQController(MyBakeryContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult FAQList()
        {
            var value = _context.FAQs.ToList();
            return Ok(value);
        }
        [HttpGet("FAQCount")]

        public IActionResult FAQCount()
        {
            var value = _context.FAQs.Count();
            return Ok(value);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = _context.FAQs.Find(id);
            return Ok(value);
        }
        [HttpPost]

        public IActionResult CreateFAQ(FAQ faq)
        {
            _context.FAQs.Add(faq);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarı ile gerçekleşti");
        }
        [HttpPut]

        public IActionResult UpdateFAQ(FAQ faq)
        {
            _context.FAQs.Update(faq);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarı ile gerçekleşti");
        }
        [HttpDelete]

        public IActionResult DeleteFAQ(int id)
        {
            var value = _context.FAQs.Find(id);
            _context.FAQs.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarı ile gerçekleşti");
        }
    }
}
