using ErrorOr;
using MediatR;
using Wims.Application.Users.Common;

namespace Wims.Application.Users.Commands.Delete
{
    public record DeleteUserCommand(
        Guid Id) : IRequest<ErrorOr<UserResult>>;
}
