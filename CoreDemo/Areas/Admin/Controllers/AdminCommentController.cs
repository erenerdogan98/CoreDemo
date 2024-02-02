using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
