using firstmvc.Data;
using firstmvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace firstmvc.Controllers
{
    public class ProductController : Controller
    {
        Applicationdbcontext db = new Applicationdbcontext();
        public IActionResult Index()
        {
            var prod = db.Products.Include(e=>e.Category).ToList();
            return View(prod);
        }
        public IActionResult Create()
        {
            var cat = db.Categories.ToList();
            return View(cat);
        }
        [HttpPost]
        public IActionResult Create(Product pro,IFormFile ImgUrl)
        {
            
            if (ImgUrl.Length>0) {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUrl.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images",fileName);
           using (var stream = System.IO.File.Create(filePath))
                {
                    ImgUrl.CopyTo(stream);

                }
                pro.ImgUrl = fileName;
            
            }

            db.Products.Add(pro);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
