using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MyBakery.WebUI.Dtos.FAQs;

namespace MyBakery.WebUI.ViewComponents
{
    public class _DefaultFAQComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultFAQComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7051/api/FAQ");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultFAQsDto>>(jsonData);
                return View(value);
            }
            return View(new List<ResultFAQsDto>());
        }
    }
}
