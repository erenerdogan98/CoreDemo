using BLL.Abstract;
using DAL.Context;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        private readonly IMessage2Service _messageService;
        private readonly MyContext _context;
        public MessageController(IMessage2Service messageService, MyContext context)
        {
            _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
            _context = context ?? throw new ArgumentNullException("context");
        }
        public async Task<IActionResult> InBox()
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.NameSurname == username).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.Email == usermail).Select(y => y.ID).FirstOrDefault();
            var values = await _messageService.GetInBoxListByWriter(writerId);
            return View(values);
        }
        public async Task<IActionResult> SendBox()
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.NameSurname == username).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.Email == usermail).Select(y => y.ID).FirstOrDefault();
            var values = await _messageService.GetSendBoxByWriterAsync(writerId);
            return View(values);
        }
        public async Task<IActionResult> MessageDetails(int id)
        {
            var value = await _messageService.GetByIdAsync(id);
            return View(value);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            // Select list for users...
            var users = _context.Users.Select(u => new SelectListItem { Text = u.NameSurname, Value = u.Id.ToString() }).ToList();

            // Send back to view with ViewBag 
            ViewBag.Users = users;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message2 message)
        {
            var username = User.Identity.Name;
            var user = _context.Users.FirstOrDefault(u => u.NameSurname == username);
            var writerId = user != null ? _context.Writers.Where(x => x.Email == user.Email).Select(y => y.ID).FirstOrDefault() : 0;
            if (message.ReceiverID == 0)
            {
                ModelState.AddModelError("ReceiverID", "Please select a receiver.");
                ViewBag.Users = _context.Users.Select(u => new SelectListItem { Text = u.NameSurname, Value = u.Id.ToString() }).ToList();
                return View();
            }

            message.SenderID = writerId;
            message.Status = true;
            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            await _messageService.AddAsync(message);
            return RedirectToAction("InBox");

            // if receiver id is null we add error to Model State , else we have receiver id and we can send message.. 
        }
    }
}
