using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    public class AdminCommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
