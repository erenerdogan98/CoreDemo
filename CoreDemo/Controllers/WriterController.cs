using BLL.Abstract;
using BLL.ValidationRules;
using CoreDemo.Models;
using DAL.Context;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        private readonly IWriterService _writerService;
        private readonly WriterValidator _writerValidator;
        private readonly MyContext _context;
        private readonly UserManager<AppUser> _userManager;

        public WriterController(IWriterService writerService, WriterValidator writerValidator, MyContext context, UserManager<AppUser> userManager)
        {
            _writerService = writerService ?? throw new ArgumentNullException(nameof(writerService));
            _writerValidator = writerValidator ?? throw new ArgumentNullException(nameof(writerValidator));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;

            var writerName = _context.Writers
                .Where(x => x.Email == userMail)
                .Select(x => x.Name)
                .FirstOrDefault();

            ViewBag.v2 = writerName;
            return View();
        }

        public IActionResult WriterProfile() => View();

        public IActionResult WriterMail() => View();

        [AllowAnonymous]
        public IActionResult Test() => View();

        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial() => PartialView();

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial() => PartialView();

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var model = new UserUpdateViewModel
            {
                mail = user.Email,
                namesurname = user.NameSurname,
                imageurl = user.ImageUrl,
                username = user.UserName
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Email = model.mail;
            user.NameSurname = model.namesurname;
            user.ImageUrl = model.imageurl;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.password);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd() => View();

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> WriterAdd(AddProfileImage model)
        {
            var writer = new Writer();

            if (model.Image != null)
            {
                var extension = Path.GetExtension(model.Image.FileName);
                var newImageName = $"{Guid.NewGuid()}{extension}";
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles", newImageName);

                using (var stream = new FileStream(location, FileMode.Create))
                {
                    await model.Image.CopyToAsync(stream);
                }

                writer.Image = newImageName;
            }
            writer.Email = model.Email;
            writer.Name = model.Name;
            writer.Password = model.Password;
            writer.Status = model.Status;
            writer.About = model.About;
            ValidationResult validationResult = _writerValidator.Validate(writer);
           if( validationResult.IsValid)
            {
                await _writerService.AddAsync(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
