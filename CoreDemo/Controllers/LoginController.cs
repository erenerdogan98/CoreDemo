using DAL.Context;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(Writer writer)
        {
            MyContext c = new MyContext();
            var data = c.Writers.FirstOrDefault(x => x.Email == writer.Email && x.Password == writer.Password);
            if (data != null)
            {
                HttpContext.Session.SetString("username", writer.Email);
                return RedirectToAction("Writer", "Blog");
            }
            else
            {
                return View();
            }
        }
    }
}
