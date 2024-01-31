using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
