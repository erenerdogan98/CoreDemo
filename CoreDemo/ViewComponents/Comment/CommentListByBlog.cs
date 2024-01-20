using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Comment
{
	public class CommentListByBlog : ViewComponent
	{
		private readonly ICommentService _commentService;
        public CommentListByBlog(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IViewComponentResult Invoke()
		{
			var values = _commentService.GetByIdAsync(2);
			return View();
		}
	}
}
