using DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        private readonly MyContext _context;
        public DashboardController(MyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IActionResult Index()
        {
            var writerId = GetWriterIdFromUser();

            ViewBag.v1 = _context.Blogs.Count().ToString();
            ViewBag.v2 = _context.Blogs.Where(x => x.WriterID == writerId).Count().ToString();
            ViewBag.v3 = _context.Categories.Count().ToString();
            return View();
        }
        private int GetWriterIdFromUser()
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users
                .Where(x => x.UserName == userName)
                .Select(y => y.Email)
                .FirstOrDefault();

            return _context.Writers
                .Where(x => x.Email == userMail)
                .Select(y => y.ID)
                .FirstOrDefault();
        }
    }
}
