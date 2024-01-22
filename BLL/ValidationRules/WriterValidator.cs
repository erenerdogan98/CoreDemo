using Entities.Concrete;
using FluentValidation;

namespace BLL.ValidationRules
{
	public class WriterValidator : AbstractValidator<Writer>
	{
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Writer name can't be null or empty!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail address can't be null or empty!");
			RuleFor(x => x.Password)
			.NotEmpty().WithMessage("Password can't be null or empty!")
			.MinimumLength(8).WithMessage("Password must consist of at least 8 characters")
			.Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$")
				.WithMessage("The password must contain at least 1 uppercase letter, 1 lowercase letter and 1 number.");
		}
	}
}
