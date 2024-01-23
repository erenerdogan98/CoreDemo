using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class WriterController1 : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
