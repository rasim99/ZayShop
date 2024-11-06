using Microsoft.AspNetCore.Mvc;

namespace ZayShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.PageName = "Dashboard";
            return View();
        }
    }
}
