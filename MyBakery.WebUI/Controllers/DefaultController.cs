using Microsoft.AspNetCore.Mvc;

namespace MyBakery.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
