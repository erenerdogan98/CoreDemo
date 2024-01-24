using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Notification
{
    public class NotificationList : ViewComponent
    {
        private readonly INotificationService _notificationService;
        public NotificationList(INotificationService notificationService)
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
