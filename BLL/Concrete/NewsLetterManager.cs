using BLL.Abstract;
using DAL.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace BLL.Concrete
{
    internal class NewsLetterManager : INewsLetterService
    {
        private readonly INewsLetterDAL _newsLetterDAL;
        public NewsLetterManager(INewsLetterDAL newsLetterDAL)
        {
            _newsLetterDAL = newsLetterDAL ?? throw new ArgumentNullException(nameof(_newsLetterDAL));
        }
        public async Task AddAsync(NewsLetter newsLetter) => await _newsLetterDAL.AddAsync(newsLetter);

        public async Task DeleteAsync(NewsLetter newsLetter) => await _newsLetterDAL.DeleteAsync(newsLetter);

        public async Task<IEnumerable<NewsLetter>> GetAllAsync() => await _newsLetterDAL.GetAllAsync();

        public async Task<IEnumerable<NewsLetter>> GetAllAsync(Expression<Func<NewsLetter, bool>> filter) => await _newsLetterDAL.GetAllAsync(filter);

        public async Task<NewsLetter> GetByIdAsync(int id) => await _newsLetterDAL.GetByIdAsync(id);

        public async Task UpdateAsync(NewsLetter newsLetter) => await _newsLetterDAL.UpdateAsync(newsLetter);
    }
}
