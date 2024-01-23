using BLL.Abstract;
using BLL.ValidationRules;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly BlogValidator _blogValidator;
        private readonly ICategoryService _categoryService;
        public BlogController(IBlogService blogService, BlogValidator blogValidator, ICategoryService categoryService)
        {
            _blogService = blogService;
            _blogValidator = blogValidator;
            _categoryService = categoryService;
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
        public async Task<IActionResult> BlogAdd()
        {
            IEnumerable<Category> categories = await _categoryService.GetAllAsync();
            List<SelectListItem> categoryValues = categories
        .Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.ID.ToString()
        })
        .ToList();
            ViewBag.cv = categoryValues;
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
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blogValue = await _blogService.GetByIdAsync(id);
            _blogService.DeleteAsync(blogValue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public async Task<IActionResult> EditBlog(int id) 
        {
            var blogValue = await _blogService.GetByIdAsync(id);
            IEnumerable<Category> categories = await _categoryService.GetAllAsync();
            List<SelectListItem> categoryValues = categories
        .Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.ID.ToString()
        })
        .ToList();
            ViewBag.cv = categoryValues;
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            blog.WriterID = 1;
            blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.Status = true;
            _blogService.UpdateAsync(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
