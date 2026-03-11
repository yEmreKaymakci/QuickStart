using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStart.WebUI.Dtos.Contacts;
using QuickStart.WebUI.Dtos.Services;
using QuickStart.WebUI.Models;

namespace QuickStart.WebUI.ViewComponents
{
    public class _DefaultFooterComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultFooterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var viewModel = new FooterViewModel();

            //1. İletişim Bilgileri
            var contactResponse = await client.GetAsync("https://localhost:7051/api/Contact");
            if (contactResponse.IsSuccessStatusCode)
            {
                var contactJson = await contactResponse.Content.ReadAsStringAsync();
                var contactValue = JsonConvert.DeserializeObject<List<ResultContactsDto>>(contactJson);
                viewModel.Contact =contactValue?.FirstOrDefault() ?? new ResultContactsDto();
            }

            //2. Hizmetler
            var serviceResponse = await client.GetAsync("https://localhost:7051/api/Service");
            if (serviceResponse.IsSuccessStatusCode)
            {
                var serviceJson = await serviceResponse.Content.ReadAsStringAsync();
                viewModel.Services = JsonConvert.DeserializeObject<List<ResultServicesDto>>(serviceJson) ?? new List<ResultServicesDto>();
            }

            return View(viewModel);
        }
    }
}
