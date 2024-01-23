using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogLastThreePost : ViewComponent
    {
        private readonly IBlogService _blogServce;
        public BlogLastThreePost(IBlogService blogService)
        {
            _blogServce = blogService;
        }
        public IViewComponentResult Invoke()
        {
            // will write later
            return View();
        }
    }
}
