 using firstmvc.Data;
using firstmvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace firstmvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Applicationdbcontext dbcontext =new Applicationdbcontext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = dbcontext.Products.ToList(); 
            return View(products);
        }

        public IActionResult Details(int productid)
        {
            var products = dbcontext.Products.Find(productid);
            if (products != null)
            {
                return View(products);
            }
            else {
                return RedirectToAction(nameof(NotFoundp));
            }
        }
        public IActionResult NotFoundp()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
