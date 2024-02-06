using BLL.Abstract;
using BLL.ValidationRules;
using DAL.Context;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly BlogValidator _blogValidator;
        private readonly ICategoryService _categoryService;
        private readonly MyContext _context;
        public BlogController(IBlogService blogService, BlogValidator blogValidator, ICategoryService categoryService, MyContext context)
        {
            _blogService = blogService ?? throw new ArgumentNullException(nameof(blogService));
            _blogValidator = blogValidator ?? throw new ArgumentNullException(nameof(blogValidator));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var values = await _blogService.GetListWithCategoryAsync();
            return View(values);
        }
        public async Task<IActionResult> ReadAll(int id)
        {
            ViewBag.i = id;
            var values = await _blogService.GetByIdAsync(id);
            return View(values);
        }
        public async Task<IActionResult> BlogListByWriter()
        {
            var writerID = GetWriterIdFromUser();
            var values = await _blogService.GetBlogsByWriterAsync(writerID);
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> BlogAdd()
        {
            ViewBag.cv = await GetCategorySelectListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BlogAdd(Blog blog)
        {
            var writerID = GetWriterIdFromUser();
            ValidationResult validationResult = _blogValidator.Validate(blog);

            if (validationResult.IsValid)
            {
                blog.Status = true;
                blog.CreateDate = DateTime.Today;
                blog.WriterID = writerID;

                await _blogService.AddAsync(blog);
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
            var categoryValues = await GetCategorySelectListAsync();
            return View(blogValue);
        }
        [HttpPost]
        public async Task<IActionResult> EditBlog(Blog blog)
        {
            var writerID = GetWriterIdFromUser();

            blog.WriterID = writerID;
            blog.CreateDate = DateTime.Today;
            blog.Status = true;
            await _blogService.UpdateAsync(blog);
            return RedirectToAction("BlogListByWriter");
        }

        private async Task<List<SelectListItem>> GetCategorySelectListAsync()
        {
            var categories = await _categoryService.GetAllAsync();

            return categories
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                })
                .ToList();
        }
        private int GetWriterIdFromUser()
        {
            var username = User.Identity.Name;  
            var usermail = _context.Users
                .Where(x => x.UserName == username)
                .Select(y => y.Email)
                .FirstOrDefault();

            return _context.Writers
                .Where(x => x.Email == usermail)
                .Select(x => x.ID)
                .FirstOrDefault();
        }
    }
}
