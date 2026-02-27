using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuickStart.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7051/api/Testimonial/TestimonialCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.TestimonialCount = jsonData;

            var responseMessage1 = await client.GetAsync("https://localhost:7051/api/Service/ServiceCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.ServiceCount = jsonData1;



            return View();
        }
    }
}
