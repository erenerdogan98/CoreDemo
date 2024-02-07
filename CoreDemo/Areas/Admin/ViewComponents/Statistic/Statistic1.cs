using BLL.Abstract;
using DAL.Context;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

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
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await _blogService.GetAllAsync();
            var blogList = blogs.ToList();
            ViewBag.v1 = blogList.Count();

            ViewBag.v2 = _context.Contacts.Count();

            ViewBag.v3 = _context.Comments.Count();

            // for weather 
            string api = "13fec22893de8dca085cb116ed27bfc4";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value");
            return View();
        }
    }
}
