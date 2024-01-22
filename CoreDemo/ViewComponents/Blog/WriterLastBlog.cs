using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
	public class WriterLastBlog : ViewComponent
	{
		private readonly IBlogService _blogService;
        public WriterLastBlog(IBlogService blogService)
        {
            _blogService = blogService ?? throw new ArgumentNullException(nameof(_blogService));
        }
        public IViewComponentResult Invoke()
        {
            var values = _blogService.GetBlogsByWriterAsync(1);
            return View(values);
        }
    }
}
