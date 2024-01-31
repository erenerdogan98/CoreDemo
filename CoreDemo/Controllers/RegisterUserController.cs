using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class RegisterUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
