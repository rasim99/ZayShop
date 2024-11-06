using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZayShop.Areas.Admin.Models.Product;
using ZayShop.Data;

namespace ZayShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        #region List
        public IActionResult Index()
        {
            ViewBag.isProductController = true;
            ViewBag.isIndexAction = true;
            ViewBag.PageName = "Product";
            var products = _context.Products.Include(p=>p.Category).ToList();
            var model=new ProductIndexVM { Products = products };
            return View(model);
        }
        #endregion

        #region Create
        [HttpGet]
        public ActionResult Create() 
        {
            var model = new ProductCreateVM
            {
                Categories = _context.Categories.Select(c=>new SelectListItem
                {
                    Text = c.Name,
                    Value=c.Id.ToString()
                }).ToList()
            };
          return View(model);
        }

        [HttpPost]
        public ActionResult Create(ProductCreateVM model) 
        {
            model.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();

			if (!ModelState.IsValid) return View(model);
            var product = _context.Products.FirstOrDefault(p=>p.Title.ToLower()==model.Title.ToLower());
            if (product is not null) 
            {
                ModelState.AddModelError("Title","Already Exists");
                return View(model);
            }
            var category = _context.Categories.Find(model.CategoryId);
            if (category is null)
            {
                ModelState.AddModelError("CategoryId","Category not found");
                return View(model);
            }

            product = new Entities.Product  
            {
                Title = model.Title,
                PhotoPath = model.PhotoPath,
                Size = model.Size,
                Price = model.Price,
                CategoryId = model.CategoryId
            };
            _context.Products.Add(product);
            _context.SaveChanges();
          return RedirectToAction(nameof(Index));
        }

		#endregion
	}
}
