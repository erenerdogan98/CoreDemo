using BLL.Abstract;
using BLL.Concrete;
using BLL.ValidationRules;
using CoreDemo.Models;
using DAL.Context;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        private readonly IWriterService _writerService;
        private readonly WriterValidator _writerValidator;
        private readonly MyContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppUserManager _appUserManager;
        public WriterController(IWriterService writerService, WriterValidator validationRules, MyContext context, UserManager<AppUser> userManager, AppUserManager appUserManager)
        {
            _writerService = writerService;
            _writerValidator = validationRules;
            _context = context;
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _appUserManager = appUserManager ?? throw new ArgumentNullException(nameof(appUserManager));
        }
        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            var writerName = _context.Writers.Where(x => x.Email == usermail).Select(x => x.Name).FirstOrDefault();
            ViewBag.v2 = writerName;
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.namesurname = values.NameSurname;
            model.imageurl = values.ImageUrl;
            model.username = values.UserName;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = model.mail;
            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
            var result = await _userManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
                return RedirectToAction("Index", "Login");

        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer writer = new Writer();
            if (p.Image != null)
            {
                var extension = Path.GetExtension(p.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.Image.CopyTo(stream);
                writer.Image = newImageName;
            }
            writer.Email = p.Email;
            writer.Name = p.Name;
            writer.Password = p.Password;
            writer.Status = p.Status;
            writer.About = p.About;
            _writerService.AddAsync(writer);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
