using KinderGarten.Interfaces;
using KinderGarten.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KinderGarten.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserInterface _userInterface;

        public UserController(UserManager<User> userManager,
                              SignInManager<User> signInManager, IUserInterface userInterface)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userInterface = userInterface;
        }

        public IActionResult Index(int UserID)
        {

            return View();
        }
        public IActionResult Login()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}