using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly IMessage2Service _messageService;
        public WriterMessageNotification(IMessage2Service messageService)
        {
            _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int id = 2;
            var values = await _messageService.GetInBoxListByWriter(id);
            return View(values);
        }
    }
}
