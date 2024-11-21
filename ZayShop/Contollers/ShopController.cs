using Microsoft.AspNetCore.Mvc;
using ZayShop.Data;
using ZayShop.Models.Category;
using ZayShop.Models.Product;
using ZayShop.Models.Shop;

namespace ZayShop.Contollers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

		public ShopController(AppDbContext context)
		{
			_context = context;
		} 

		public IActionResult Index()
        {
            var categories=_context.Categories.ToList();
            var products=_context.Products.ToList();
            var categoriesList= new List<CategoryVM>();
            var productsList = new List<ProductVM>();
            foreach (var category in categories)
            {
                var categoryVM = new CategoryVM
                {
                    Name = category.Name
                };
                categoriesList.Add(categoryVM);
            }

            foreach (var product in products)
            {
                var productVM = new ProductVM
                {
                    Title = product.Title,
                    PhotoName = product.PhotoName,
                    Size = product.Size,
                    Price = product.Price
                };
                productsList.Add(productVM);
            }
            var model=new ShopIndexVM { Categories = categoriesList,Products=productsList};
            return View(model);
        }

        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
