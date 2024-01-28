using BLL.Abstract;
using DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        private readonly IBlogService _blogService;
        private readonly MyContext _context;
        public Statistic1(IBlogService blogService, MyContext context)
        {
            _blogService = blogService ?? throw new ArgumentNullException(nameof(blogService));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IViewComponentResult> Invoke()
        {
            var blogs = await _blogService.GetAllAsync();
            var blogList = blogs.ToList();
            ViewBag.v1 = blogList.Count();

            ViewBag.v2 = _context.Contacts.Count();

            ViewBag.v3 = _context.Comments.Count();
            return View();
        }
    }
}
