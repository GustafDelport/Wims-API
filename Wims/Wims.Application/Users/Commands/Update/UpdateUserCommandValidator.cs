using FluentValidation;

namespace Wims.Application.Users.Commands.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        //
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .MinimumLength(3).WithMessage("Name should be a minimum of 3 characters")
                .MaximumLength(25).WithMessage("Name should be a maximum of 25 characters")
                .When(x => !string.IsNullOrEmpty(x.FirstName));

            RuleFor(x => x.LastName)
                .MinimumLength(3).WithMessage("Lastname should be a minimum of 3 characters")
                .MaximumLength(25).WithMessage("Lastname should be a maximum of 25 characters")
                .When(x => !string.IsNullOrEmpty(x.LastName));

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Ensure that the email address is correct")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Your password cannot be empty.")
                .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                .Matches(@"[\!\?\*\.\@]+").WithMessage("Your password must contain at least one (! ? * . @).")
                .When(x => !string.IsNullOrEmpty(x.Password));
        }
    }
}
