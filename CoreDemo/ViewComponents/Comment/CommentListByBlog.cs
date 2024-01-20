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
        public IViewComponentResult Invoke(int id)
		{
			var values = _commentService.GetByIdAsync(id);
            if (values == null)
            {
                ViewBag.ShowAddCommentMessage = true; 
            }
            return View();
		}
	}
}
