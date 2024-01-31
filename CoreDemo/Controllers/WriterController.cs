using BLL.Abstract;
using BLL.ValidationRules;
using CoreDemo.Models;
using DAL.Context;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        private readonly IWriterService _writerService;
        private readonly WriterValidator _writerValidator;
        private readonly MyContext _context;
        public WriterController(IWriterService writerService, WriterValidator validationRules, MyContext context)
        {
            _writerService = writerService;
            _writerValidator = validationRules;
            _context = context;

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
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = _context.Writers.Where(x => x.Email == usermail).Select(x => x.ID).FirstOrDefault();
            var writerValues = await _writerService.GetByIdAsync(writerID);
            return View(writerValues);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            ValidationResult validationResult = _writerValidator.Validate(writer);
            if (validationResult.IsValid)
            {
                _writerService.UpdateAsync(writer);
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
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/WriterImageFiles" ,newImageName);
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
