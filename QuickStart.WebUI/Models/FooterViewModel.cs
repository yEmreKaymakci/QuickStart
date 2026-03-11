using QuickStart.WebUI.Dtos.Contacts;
using QuickStart.WebUI.Dtos.Services;

namespace QuickStart.WebUI.Models
{
    public class FooterViewModel
    {
        public ResultContactsDto Contact { get; set; }

        public List<ResultServicesDto> Services { get; set; }
    }
}
