using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStart.WebUI.Dtos.NotificationTypes;

namespace QuickStart.WebUI.Controllers
{
    public class AdminNotificationTypeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminNotificationTypeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7051/api/NotificationType");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNotificationTypeDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateNotificationType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotificationType(CreateNotificationTypeDto model)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(model);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7051/api/NotificationType", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotificationType(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7051/api/NotificationType/" + id);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<UpdateNotificationTypeDto>(jsonData);

            return View(values);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateNotificationType(UpdateNotificationTypeDto model)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(model); 

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7051/api/NotificationType", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(model);

        }

        public async Task<IActionResult> DeleteNotificationType(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.DeleteAsync("https://localhost:7051/api/NotificationType?id=" + id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return BadRequest();

        }
    }
}
