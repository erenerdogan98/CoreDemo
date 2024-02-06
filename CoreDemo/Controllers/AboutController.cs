using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class AboutController : Controller
	{
		private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService ?? throw new ArgumentNullException(nameof(_aboutService));
        }
        public async Task<IActionResult> Index()
		{
            var values = await _aboutService.GetAllAsync();
            return View(values);
		}
		public PartialViewResult SocialMediaAbout()
		{		
			return PartialView();
		}
	}
}
