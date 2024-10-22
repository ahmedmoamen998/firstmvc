using firstmvc.Data;
using firstmvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstmvc.Controllers
{
    public class CreateController : Controller
    {
        Applicationdbcontext db = new Applicationdbcontext();   
        public IActionResult Index()
        {
            var category = db.Categories.Include(e=>e.Products).ToList();
            return View(category);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            var category = db.Categories.ToList();
            return View(category);
        }
        [HttpPost]
        public IActionResult AddCategory(Category Category)
        {
            db.Categories.Add(Category);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

        } 
        public IActionResult Edit(int categoryId)
        {
            var categoryy = db.Categories.Find(categoryId);
            return View(categoryy);
        }
        [HttpPost]
        public IActionResult Edit(Category Category)
        {
            db.Categories.Update(Category);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Delete(int categoryId)
        {
            var cat = new Category()
            {
                Id = categoryId
            };
            db.Categories.Remove(cat);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
