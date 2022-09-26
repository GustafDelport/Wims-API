using FluentValidation;
using Wims.Application.Users.Queries.RetrieveUser;

namespace Wims.Application.Users.Commands.Delete
{
    public class DeleteUserCommandValidator : AbstractValidator<RetrieveUserQuery>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
