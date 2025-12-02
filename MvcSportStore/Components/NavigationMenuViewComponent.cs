using Microsoft.AspNetCore.Mvc;
using MvcSportStore.Data;

namespace MvcSportStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        StoreDbContext _context;
        public NavigationMenuViewComponent(StoreDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var products = _context.Products;
            var productCategories = products.Select(x => x.Category);
            var categories = productCategories.Distinct().OrderBy(x => x);
            return View(categories);
        }
    }
}
