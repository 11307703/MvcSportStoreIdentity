using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcSportStore.Data;
using MvcSportStore.Models;
using MvcSportStore.ViewModels;

namespace MvcSportStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        StoreDbContext _context;
        ProductRepository _productRepository;
        public HomeController(ILogger<HomeController> logger, StoreDbContext context)
        {
            _logger = logger;
            _context = context;      
            _productRepository=new ProductRepository(_context.Products);
        }
        public IActionResult Index(int id = 1, string? category=null)
        {
            int filter = PagingSettings.ProductPagination;
            var pm=_productRepository.GetProductModel(id, category);
            return View(pm);
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
