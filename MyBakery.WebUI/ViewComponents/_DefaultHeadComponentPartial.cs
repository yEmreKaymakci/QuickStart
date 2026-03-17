using Microsoft.AspNetCore.Mvc;

namespace MyBakery.WebUI.ViewComponents
{
    public class _DefaultHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
