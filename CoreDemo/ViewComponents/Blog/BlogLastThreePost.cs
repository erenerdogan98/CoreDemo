using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogLastThreePost : ViewComponent
    {
        private readonly IBlogService _blogService;
        public BlogLastThreePost(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke()
        {
            // To take last 3 blogs with LINQ
            var lastThreeBlogs = _blogService.GetAllAsync().Result
                .OrderBy(blog => blog.CreateDate) // To date (first one , the latest)
                .TakeLast(3) // take last 3 
                .ToList();

            return View(lastThreeBlogs);
 
        }
    }
}
