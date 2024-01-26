using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly IMessageService _messageService;
        public WriterMessageNotification(IMessageService messageService)
        {
            _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string reciever;
            reciever = "test123@gmail.com";
            var values = await _messageService.GetInBoxListByWriter(reciever);
            return View(values);
        }
    }
}
