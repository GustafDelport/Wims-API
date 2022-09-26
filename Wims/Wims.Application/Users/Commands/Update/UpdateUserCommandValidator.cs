using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wims.Application.Users.Commands.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {   
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty().WithMessage("Your password cannot be empty.")
                .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                .Matches(@"[\!\?\*\.\@]+").WithMessage("Your password must contain at least one (! ? * . @).");
        }
    }
}
