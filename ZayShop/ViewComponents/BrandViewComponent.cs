using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZayShop.Data;
using ZayShop.Models.Brand;

namespace ZayShop.ViewComponents
{
    public class BrandViewComponent :ViewComponent
    {
        private readonly AppDbContext _context;

        public BrandViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var model = new BrandViewComponentVM
            {
              Photos=_context.BrandPhotos.ToList(),
              Brand=_context.Brand.FirstOrDefault()
            };
            return View(model);
        }
    }
}
