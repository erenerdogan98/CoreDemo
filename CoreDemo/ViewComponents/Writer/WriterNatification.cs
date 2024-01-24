using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNatification : ViewComponent
    {
        private readonly INotificationService _notificationService;
        public WriterNatification(INotificationService notificationService)
        {
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }
        public IViewComponentResult Invoke()
        {
            var values = _notificationService.GetAllAsync();
            return View(values);
        }
    }
}
