using BLL.Abstract;
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
            var values = _blogService.GetAllAsync();
            return View(values);
        }
    }
}
