using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var values = await _categoryService.GetAllAsync();
            var valuesList = values.ToList(); // IEnumerable<T> to List<T>
            var pagedList = valuesList.ToPagedList(page, 3);
            return View(pagedList);
        }
    }
}
