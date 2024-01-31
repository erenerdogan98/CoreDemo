using BLL.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class CommentController : Controller
	{
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult PartialAddComment(Comment comment)
		{
			comment.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
			comment.Status = true;
			comment.BlogID = 1;
			_commentService.AddAsync(comment);
			return PartialView();
		}
		public PartialViewResult CommentListByBlog() 
		{
			return PartialView();
		}
	}
}
