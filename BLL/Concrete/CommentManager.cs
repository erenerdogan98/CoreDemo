using BLL.Abstract;
using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
	public class CommentManager : ICommentService
	{
		private readonly ICommentDAL _commentDAL;
        public CommentManager(ICommentDAL commentDAL)
        {
            _commentDAL = commentDAL ?? throw new ArgumentNullException(nameof(_commentDAL));
        }
        public async Task AddAsync(Comment comment) => await _commentDAL.AddAsync(comment);

		public async Task DeleteAsync(Comment comment) => await _commentDAL.DeleteAsync(comment);

		public async Task<IEnumerable<Comment>> GetAllAsync() => await _commentDAL.GetAllAsync();

		public async Task<IEnumerable<Comment>> GetAllAsync(Expression<Func<Comment, bool>> filter) => await _commentDAL.GetAllAsync(filter);

		public async Task<Comment> GetByIdAsync(int id) => await _commentDAL.GetByIdAsync(id);

		public async Task<List<Comment>> GetListWithBlogAsync() => await _commentDAL.GetListWithBlogAsync();

        public async Task UpdateAsync(Comment comment) => await _commentDAL.UpdateAsync(comment);
	}
}
