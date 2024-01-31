using CoreDemo.Models;
using DAL.Context;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel user)
        {
            if ( ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.userName, user.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                return View();
            }
        }
        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Index(Writer writer)
        //{
        //    MyContext c = new MyContext();
        //    var data = c.Writers.FirstOrDefault(x => x.Email == writer.Email && x.Password == writer.Password);
        //    if (data != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, writer.Email)
        //        };
        //        var userIdentity = new ClaimsIdentity(claims, "a");
        //        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
        //        await HttpContext.SignInAsync(claimsPrincipal);
        //        return RedirectToAction("Index", "Dashboard");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}
