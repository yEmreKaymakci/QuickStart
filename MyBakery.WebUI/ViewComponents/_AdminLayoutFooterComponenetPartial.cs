using Microsoft.AspNetCore.Mvc;

namespace MyBakery.WebUI.ViewComponents
{
    public class _AdminLayoutFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();

        }
    }
}
