using MyBakery.WebUI.Dtos.Contacts;
using MyBakery.WebUI.Dtos.Services;

namespace MyBakery.WebUI.Models
{
    public class FooterViewModel
    {
        public ResultContactsDto Contact { get; set; }

        public List<ResultServicesDto> Services { get; set; }
    }
}
