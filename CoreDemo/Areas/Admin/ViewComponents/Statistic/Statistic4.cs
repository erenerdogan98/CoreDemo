using DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        private readonly MyContext _context;
        public Statistic4(MyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _context.Admins.Where( x => x.ID == 1 ).Select(x => x.Name).FirstOrDefault(); 
            
            ViewBag.v2 = _context.Admins.Where( x => x.ID == 1 ).Select(x => x.ImageURL).FirstOrDefault();

            ViewBag.v3 = _context.Admins.Where( x => x.ID == 1 ).Select(x => x.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
