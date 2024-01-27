using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessage2Service _messageService;
        public MessageController(IMessage2Service messageService)
        {
            this._messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
        }
        public async Task<IActionResult> InBox()
        {
            int id = 2;
            var values = await _messageService.GetInBoxListByWriter(id);
            return View();
        }
    }
}
