using BLL.Abstract;
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
        public async Task<IActionResult> MessageDetails(int id)
        {
            var value = await _messageService.GetByIdAsync(id);
            return View(value);
        }
    }
}
