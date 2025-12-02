using Microsoft.AspNetCore.Mvc;
using MvcSportStore.Data;
using MvcSportStore.Models;

namespace MvcSportStore.Controllers
{
    public class ProductController : Controller
    {
        StoreDbContext _context;
        public ProductController(StoreDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Invalid Data! -> " + ex.Message.Substring(50));
                }
            }
            return View();

        }

        public IActionResult Delete(long id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View(_context.Products);
        }
    }
}
