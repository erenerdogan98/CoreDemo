using BLL.Abstract;
using BLL.ValidationRules;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly BlogValidator _blogValidator;
        public BlogController(IBlogService blogService , BlogValidator _blogValidator)
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
            ValidationResult validationResult = _blogValidator.Validate(blog);
            if (validationResult.IsValid)
            {
                blog.Status = true;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = 1;
                _blogService.AddAsync(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
