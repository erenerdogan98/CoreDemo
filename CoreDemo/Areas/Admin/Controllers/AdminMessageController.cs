using BLL.Abstract;
using DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        private readonly MyContext _context;
        private readonly IMessage2Service _messageService;
        public AdminMessageController(MyContext context, IMessage2Service messageService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
        }
        public async Task<IActionResult> Inbox()
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.NameSurname == username).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.Email == usermail).Select(y => y.ID).FirstOrDefault();
            var values = await _messageService.GetInBoxListByWriter(writerId);
            return View(values);
        }
    }
}
