using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStart.WebUI.Dtos.Notification;

namespace QuickStart.WebUI.Controllers
{
    [Authorize]
    public class AdminDashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string ApiBase = "https://localhost:7051/api";

        public AdminDashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var tasks = new[]
            {
                FetchInt(client, $"{ApiBase}/Testimonial/TestimonialCount"),
                FetchInt(client, $"{ApiBase}/Service/ServiceCount"),
                FetchInt(client, $"{ApiBase}/Message/MessageCount"),
                FetchInt(client, $"{ApiBase}/Subscribe/SubscribeCount"),
                FetchInt(client, $"{ApiBase}/FAQ/FAQCount"),
            };

            await Task.WhenAll(tasks);

            ViewBag.TestimonialCount = tasks[0].Result;
            ViewBag.ServiceCount = tasks[1].Result;
            ViewBag.MessageCount = tasks[2].Result;
            ViewBag.SubscribeCount = tasks[3].Result;
            ViewBag.FAQCount = tasks[4].Result;

            var notifResponse = await client.GetAsync($"{ApiBase}/Notification/GetNotificationListWithNotificationType");
            var notifJson = await notifResponse.Content.ReadAsStringAsync();
            var notifications = JsonConvert.DeserializeObject<List<ResultNotificationWithNotificationTypeDto>>(notifJson)
                                ?? new List<ResultNotificationWithNotificationTypeDto>();

            ViewBag.UnreadCount = notifications.Count(x => !x.IsRead);
            ViewBag.RecentNotifications = notifications.Take(8).ToList();

            return View();
        }

        private static async Task<int> FetchInt(HttpClient client, string url)
        {
            try
            {
                var res = await client.GetAsync(url);
                var body = await res.Content.ReadAsStringAsync();
                return int.TryParse(body, out var n) ? n : 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
