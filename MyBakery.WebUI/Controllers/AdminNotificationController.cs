using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MyBakery.WebUI.Dtos.Notification;
using MyBakery.WebUI.Dtos.NotificationTypes;

namespace MyBakery.WebUI.Controllers
{
    [Authorize]
    public class AdminNotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminNotificationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private async Task LoadNotificationTypesAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7051/api/NotificationType");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var types = JsonConvert.DeserializeObject<List<ResultNotificationTypeDto>>(json) ?? new();
                ViewBag.NotificationTypes = types;
            }
            else
            {
                ViewBag.NotificationTypes = new List<ResultNotificationTypeDto>();
            }
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7051/api/Notification/GetNotificationListWithNotificationType");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNotificationWithNotificationTypeDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateNotification()
        {
            await LoadNotificationTypesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationWithNotificationTypeDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7051/api/Notification", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            await LoadNotificationTypesAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7051/api/Notification/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateNotificationWithNotificationTypeDto>(jsonData);

            await LoadNotificationTypesAsync();
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationWithNotificationTypeDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7051/api/Notification", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            await LoadNotificationTypesAsync();
            return View(model);
        }

        public async Task<IActionResult> DeleteNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7051/api/Notification?id=" + id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return BadRequest();
        }
    }
}
