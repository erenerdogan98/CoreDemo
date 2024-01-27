using Entities.Concrete;
using FluentValidation;

namespace BLL.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category name can not be null or empty!");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Category name can be maximum 50 character!");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Category name can be minimum 2 character!");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Category description can not be null or empty!");
        }
    }
}
