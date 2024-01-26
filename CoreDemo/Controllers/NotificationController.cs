using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AllNotification() 
        {
            var values = await _notificationService.GetAllAsync();
            return View(values);
        }
    }
}
