using Microsoft.AspNetCore.Mvc;

namespace MyBakery.WebUI.ViewComponents
{
    public class _DefaultScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
