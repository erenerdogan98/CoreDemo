using BLL.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IActionResult Index()
        {
            var values = _blogService.GetListWithCategoryAsync();
            return View(values);
        }
        public IActionResult ReadAll(int id)
        {
            ViewBag.i = id;
            var values = _blogService.GetByIdAsync(id);
            return View(values);
        }
        public IActionResult BlogListByWriter(int id) 
        {
            var values = _blogService.GetBlogsByWriterAsync(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            return View();
        }
    }
}
