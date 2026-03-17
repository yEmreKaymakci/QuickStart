using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MyBakery.WebUI.Dtos.FeatureServices;
using MyBakery.WebUI.Dtos.Sliders;

namespace MyBakery.WebUI.ViewComponents
{
    public class _DefaultSliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7051/api/Slider");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
                var firstItem = values?.FirstOrDefault();
                return View(firstItem);
            }
            return View(new List<ResultSliderDto>());
        }
    }
}
