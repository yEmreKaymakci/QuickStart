using Microsoft.AspNetCore.Mvc;

namespace MyBakery.WebUI.ViewComponents
{
    public class _DefaultNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
