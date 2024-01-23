using Entities.Concrete;
using FluentValidation;

namespace BLL.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog title can not be null or empty.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Blog content can not be null or empty.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Blog image can not be null or empty.");

            RuleFor(x => x.Title).MaximumLength(159).WithMessage("Please , write your title less than 160 character!");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Please , write your title more than 4 character!");
        }
    }
}
