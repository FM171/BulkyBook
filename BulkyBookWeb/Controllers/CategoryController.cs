using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Remoting;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)

            {
                return NotFound();
             }
            var categoryFromDb = _db.Categories.SingleOrDefault(c => c.Id == id);

            if (categoryFromDb == null)
            { 
                return NotFound();
            }
            return View(categoryFromDb);
        }

        public IActionResult Create() // GET action method
        {
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj) // GET action method
        {   
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();//this send changes to db
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj) // GET action method
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();//this send changes to db
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
