using Microsoft.AspNetCore.Mvc;

namespace ZayShop.Contollers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.IsContactPage=true;
            return View();
        }
    }
}
