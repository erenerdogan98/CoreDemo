using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController : Controller
    {
        private readonly IBlogService _blogService;
        public AdminBlogController(IBlogService blogService)
        {
            _blogService = blogService ?? throw new ArgumentNullException(nameof(blogService));
        }
        public async Task<IActionResult> Index()
        {
            var values = await _blogService.GetListWithCategoryAsync();
            return View(values);
        }
    }
}
