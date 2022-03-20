using Microsoft.AspNetCore.Mvc;
using WebBooks.Data;
using WebBooks.Models;

namespace WebBooks.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // METHOD: GET
        // LINKS: 
        // Category/Index/
        // Category/Index
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _db.Categories;
            return View(categoryList);
        }

        // METHOD: GET
        // LINKS:
        // Category/Create/
        // Category/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // METHOD: POST
        // LINKS:
        // Category/Create/
        // Category/Create
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                //ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name!");
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name!");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // METHOD: GET
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var c = _db.Categories.FirstOrDefault(u => u.Id == id);
            
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            
            return View(categoryFromDb);
        }

        // METHOD: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if(ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category edited successfully!";
                return RedirectToAction("index");
            }
            return View(obj);
        }

        // METHOD: GET
        public IActionResult Delete(int?id)
        {
            if(id==null || id ==0)
            {
                return NotFound();
            }
            var category = _db.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // METHOD: POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
