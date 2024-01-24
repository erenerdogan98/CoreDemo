using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CategoryListDashboard(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(_categoryService));
        }
        public IViewComponentResult Invoke()
        {
            var values = _categoryService.GetAllAsync();
            return View(values);
        }
    }
}
