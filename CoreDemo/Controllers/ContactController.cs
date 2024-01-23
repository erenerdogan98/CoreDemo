using BLL.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(_contactService));
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.Status = true;
            _contactService.AddAsync(contact);
            return RedirectToAction("Index", "Blog");
        }
    }
}
