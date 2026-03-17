using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MyBakery.WebUI.Dtos.FeatureServices;
using MyBakery.WebUI.Dtos.Services;

namespace MyBakery.WebUI.ViewComponents
{
    public class _DefaultFeatureServiceComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultFeatureServiceComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7051/api/FeatureService");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureServiceDto>>(jsonData);
                var firstThreeItem = values.Take(3).ToList();
                return View(firstThreeItem);
            }
            return View(new List<ResultFeatureServiceDto>());
        }
    }
}
