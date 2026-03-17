using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MyBakery.WebUI.Dtos.Notification;

namespace MyBakery.WebUI.Controllers
{
    public class DefaultNotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultNotificationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> SendNotification(CreateNotificationWithNotificationTypeDto dto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7051/api/Notification", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Bildiriminiz başarıyla iletildi. Teşekkür ederiz!";
                return RedirectToAction("Index", "Default", null, "contact");
            }

            TempData["ErrorMessage"] = "Bildirim gönderilirken bir hata oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("Index", "Default", null, "contact");
        }
    }
}
