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
        public async Task<IActionResult> MessageDetails(int id)
        {
            var value = await _messageService.GetByIdAsync(id);
            return View(value);
        }
    }
}
