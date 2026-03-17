using Microsoft.AspNetCore.Mvc;

namespace MyBakery.WebUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MarkeAsRead(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7051/api/Notification/MarkeAsRead/{id}");

            // Billing bildirimi okunduktan sonra mevcut sayfaya geri dön
            var referer = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(referer))
                return Redirect(referer);

            return RedirectToAction("Index", "Default");
        }
    }
}
