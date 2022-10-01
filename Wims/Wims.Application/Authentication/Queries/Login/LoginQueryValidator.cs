﻿using FluentValidation;

namespace Wims.Application.Authentication.Queries.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty().WithMessage("Your password cannot be empty.");
        }
    }
}
