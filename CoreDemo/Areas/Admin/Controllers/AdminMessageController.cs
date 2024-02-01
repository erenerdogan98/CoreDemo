using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    public class AdminMessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
