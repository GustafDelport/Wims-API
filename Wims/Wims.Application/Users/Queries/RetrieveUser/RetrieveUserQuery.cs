using ErrorOr;
using MediatR;
using Wims.Application.Users.Common;

namespace Wims.Application.Users.Queries.RetrieveUser
{
    public record RetrieveUserQuery(
        Guid Id) : IRequest<ErrorOr<UserResult>>;
}
