using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcSportStore.ViewModels.IdentityViewModels;

namespace MvcSportStore.Controllers
{
    public class AccountController : Controller
    {
        #region DI 
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        public AccountController(
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #endregion
        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                //DI - Service - SignInResult
                return RedirectToAction("Index", "Home");

            }
            return View(model);
        }
        #endregion
        #region Logout
        [HttpGet]
        public IActionResult Logout()
        {
            return View("Login");
        }
        #endregion
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //DI - Service - IdentityResult
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        #endregion
    }
}
