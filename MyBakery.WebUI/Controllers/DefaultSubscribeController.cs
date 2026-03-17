using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MyBakery.WebUI.Dtos.Subscribes;

namespace MyBakery.WebUI.Controllers
{
    public class DefaultSubscribeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultSubscribeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> AddSubscriber(CreateSubscribeDto createSubscribeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSubscribeDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // API'ndeki subscribe ucuna post atıyoruz
            var responseMessage = await client.PostAsync("https://localhost:7051/api/Subscribe", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Bültenimize başarıyla abone oldunuz!";
            }
            else
            {
                TempData["ErrorMessage"] = "Abonelik sırasında bir hata oluştu.";
            }

            // Sayfa yenilendikten sonra kullanıcının doğrudan Footer'a kaymasını sağlıyoruz ("footer" id'si ile)
            return RedirectToAction("Index", "Default", null, "footer");
        }
    }
}
