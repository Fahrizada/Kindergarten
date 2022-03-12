using KinderGarten.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KinderGarten.Controllers
{
    public class SessionController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public SessionController(UserManager<User> userManager,
                              SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View("PrikazLogina");
        }
        public IActionResult Login()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}