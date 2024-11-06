using Microsoft.AspNetCore.Mvc;

namespace ZayShop.Contollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
