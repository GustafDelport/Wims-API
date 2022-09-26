using ErrorOr;
using MediatR;
using Wims.Application.Users.Common;

namespace Wims.Application.Users.Commands.Update
{
    public record UpdateUserCommand(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<ErrorOr<UserResult>>;
}
