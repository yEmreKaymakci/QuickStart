using Microsoft.AspNetCore.Mvc;

namespace MyBakery.WebUI.Controllers
{
    public class _AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
