using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStart.WebUI.Dtos.Contacts;
using QuickStart.WebUI.Dtos.NotificationTypes;

namespace QuickStart.WebUI.ViewComponents
{
    public class _DefaultContactComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultContactComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            // İletişim bilgilerini çek
            ResultContactsDto? contactInfo = null;
            var contactResponse = await client.GetAsync("https://localhost:7051/api/Contact");
            if (contactResponse.IsSuccessStatusCode)
            {
                var json = await contactResponse.Content.ReadAsStringAsync();
                var contacts = JsonConvert.DeserializeObject<List<ResultContactsDto>>(json);
                contactInfo = contacts?.FirstOrDefault();
            }
            contactInfo ??= new ResultContactsDto();

            // Bildirim türlerini çek (dropdown için)
            List<ResultNotificationTypeDto> notificationTypes = new();
            var typesResponse = await client.GetAsync("https://localhost:7051/api/NotificationType");
            if (typesResponse.IsSuccessStatusCode)
            {
                var json = await typesResponse.Content.ReadAsStringAsync();
                notificationTypes = JsonConvert.DeserializeObject<List<ResultNotificationTypeDto>>(json) ?? new();
            }

            return View((contactInfo, notificationTypes));
        }
    }
}
