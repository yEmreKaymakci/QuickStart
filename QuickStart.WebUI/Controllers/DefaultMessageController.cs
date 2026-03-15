using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStart.WebUI.Dtos.Messages;

namespace QuickStart.WebUI.Controllers
{
    public class DefaultMessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultMessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessagesDto createMessagesDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessagesDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7051/api/Message", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Mesajınız başarıyla iletildi. Teşekkür ederiz!";

                // DİKKAT: 4. parametre olan "contact", sayfanın doğrudan o bölüme kaymasını sağlar.
                return RedirectToAction("Index", "Default", null, "contact");
            }

            TempData["ErrorMessage"] = "Mesaj gönderilirken bir hata oluştu. Lütfen tekrar deneyin.";

            // Aynı şekilde hata durumunda da aşağıda kalsın
            return RedirectToAction("Index", "Default", null, "contact");
        }
    }
}
