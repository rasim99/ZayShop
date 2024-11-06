using Microsoft.AspNetCore.Mvc;

namespace ZayShop.Contollers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
