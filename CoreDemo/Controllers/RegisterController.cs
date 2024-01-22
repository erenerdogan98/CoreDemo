using BLL.Abstract;
using BLL.ValidationRules;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IWriterService _writerService;
		private readonly WriterValidator _writerValidator;
        public RegisterController(IWriterService writerService, WriterValidator writerValidator)
        {
            _writerService = writerService;
			_writerValidator = writerValidator;
        }
        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Writer writer)
		{
			ValidationResult validationResult = _writerValidator.Validate(writer);
			if(validationResult.IsValid)
			{
				writer.Status = true;
				writer.About = "Test";
				_writerService.AddAsync(writer);
				return RedirectToAction("Index", "Blog");
			}
			else
			{
				foreach(var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
	}
}
