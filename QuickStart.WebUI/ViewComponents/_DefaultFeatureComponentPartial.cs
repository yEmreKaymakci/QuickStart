using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStart.WebUI.Dtos.Features;

namespace QuickStart.WebUI.ViewComponents
{
    public class _DefaultFeatureComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var respomse = await client.GetAsync("https://localhost:7051/api/Feature");

            if (respomse.IsSuccessStatusCode)
            {
                var jsonData = await respomse.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultFeaturesDto>>(jsonData);

                return View(value);
            }

            return View(new List<ResultFeaturesDto>());
        }
    }
}
