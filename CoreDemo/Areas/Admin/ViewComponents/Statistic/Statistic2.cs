using BLL.Abstract;
using DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        private readonly MyContext _context;
        public Statistic2( MyContext context )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IViewComponentResult> Invoke()
        {
            ViewBag.v2 = _context.Contacts.Count();

            ViewBag.v3 = _context.Comments.Count();
            return View();
        }
    }
}
