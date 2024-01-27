using BLL.Abstract;
using BLL.ValidationRules;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly CategoryValidator _categoryValidator;
        public CategoryController(ICategoryService categoryService, CategoryValidator categoryValidator)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _categoryValidator = categoryValidator ?? throw new ArgumentNullException(nameof(categoryValidator));
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var values = await _categoryService.GetAllAsync();
            var valuesList = values.ToList(); // IEnumerable<T> to List<T>
            var pagedList = valuesList.ToPagedList(page, 3);
            return View(pagedList);
        }
        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            ValidationResult validationResult = _categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                category.Status = true;
                await _categoryService.AddAsync(category);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach ( var item in validationResult.Errors )
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
