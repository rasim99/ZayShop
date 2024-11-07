using Microsoft.AspNetCore.Mvc;
using ZayShop.Areas.Admin.Models.Slider;
using ZayShop.Data;

namespace ZayShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        #region List
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.isSliderController = true;
            ViewBag.isIndexAction = true;
            ViewBag.PageName = "Slider";
            var model = new SliderIndexVM { Sliders = _context.Sliders.ToList() };
            return View(model);
        }

        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.PageName = "Slider";

            return View();
        }
        [HttpPost]
        public IActionResult Create(SliderCreateVM model)
        {
            if (!ModelState.IsValid) return View(model);
            var slider = _context.Sliders.FirstOrDefault(s => s.Name.ToUpper() == model.Name.ToUpper());
            if (slider is not null)
            {
                ModelState.AddModelError("Name", "Already exists");
                return View(model);
            }
            slider = new Entities.Slider
            {
                PhotoPath = model.PhotoPath,
                Name = model.Name,
                Title = model.Title,
                Description = model.Description
            };
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            var slider = _context.Sliders.Find(id);
            if (slider is null) return NotFound();
            var model = new SliderUpdateVM
            {
                  Description = slider.Description,
                  PhotoPath = slider.PhotoPath,
                  Name = slider.Name,
                  Title = slider.Title
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id,SliderUpdateVM model)
        {
            if (!ModelState.IsValid) return View(model);
            var slider = _context.Sliders.Find(id);
            if (slider is null) return NotFound();
            var isExist=_context.Sliders.Any(x => x.Name.ToLower()==model.Name && x.Id!=slider.Id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "ALready exists");
                return View(model);
            }
           
            slider.PhotoPath = model.PhotoPath;
            slider.Name = model.Name;
            slider.Title = model.Title;
            slider.Description = model.Title;
            slider.ModifiedAt=DateTime.Now;
            _context.Sliders.Update(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var slider = _context.Sliders.Find(id);
            if (slider is null) return NotFound();
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
