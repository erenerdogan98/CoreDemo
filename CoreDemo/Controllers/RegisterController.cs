using BLL.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IWriterService _writerService;
        public RegisterController(IWriterService writerService)
        {
            _writerService = writerService;
        }
        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Writer writer)
		{
			writer.Status = true;
			writer.About = "Test";
			_writerService.AddAsync(writer);
			return RedirectToAction("Index", "Blog");
		}
	}
}
