using BLL.Abstract;
using DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly IMessage2Service _messageService;
        private readonly MyContext _context;
        public WriterMessageNotification(IMessage2Service messageService, MyContext context)
        {
            _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
            _context = context ?? throw new ArgumentNullException("_context");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var username = User.Identity.Name;
            var usermail = _context.Users.Where(x => x.NameSurname == username).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.Email == usermail).Select(y => y.ID).FirstOrDefault();
            var values = await _messageService.GetInBoxListByWriter(writerId);
            return View(values);
        }
    }
}
