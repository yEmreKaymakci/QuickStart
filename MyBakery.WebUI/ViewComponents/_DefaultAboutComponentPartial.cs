using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MyBakery.WebUI.Dtos.Abouts;

namespace MyBakery.WebUI.ViewComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7051/api/About");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutsDto>>(jsonData);
                var firstItem = values?.FirstOrDefault();
                return View(firstItem);
            }
            return View(new ResultAboutsDto());
        }
    }
}
