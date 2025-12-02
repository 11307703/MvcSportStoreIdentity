using Microsoft.AspNetCore.Mvc;
using MvcSportStore.ViewModels;

namespace MvcSportStore.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult PagingSettingsView()
        {
            var settings = new PagingSettingViewModel();
            settings.ProductPagination = PagingSettings.ProductPagination;
            return View(settings);
        }
        [HttpPost]
        public IActionResult PagingSettingsView(PagingSettingViewModel settings)
        {
            PagingSettings.ProductPagination = settings.ProductPagination;
            return RedirectToAction("Index", "Home");
        }
    }
}
