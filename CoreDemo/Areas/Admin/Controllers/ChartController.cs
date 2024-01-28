using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryClass> categories = new List<CategoryClass>();
            categories.Add(new CategoryClass
            {
                Name = "Technology",
                Count = 10,
            });
            categories.Add(new CategoryClass
            {
                Name = "Software",
                Count = 15,
            });
            categories.Add(new CategoryClass
            {
                Name = "Sport",
                Count = 5,
            });
            return Json(new { jsonlist = categories});
        }
    }
}
