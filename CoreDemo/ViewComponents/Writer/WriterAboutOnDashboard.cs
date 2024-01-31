using BLL.Abstract;
using DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        private readonly IWriterService _writerService;
        private readonly MyContext _context;
        public WriterAboutOnDashboard(IWriterService writerService , MyContext context)
        {
            _writerService = writerService;
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            ViewBag.v = username;

            var usermail = _context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();


            var writerID = _context.Writers.Where(x => x.Email == usermail).Select(x => x.ID).FirstOrDefault();
            var values = _writerService.GetWriterByIdAsync(writerID);
            return View(usermail);
        }
    }
}
