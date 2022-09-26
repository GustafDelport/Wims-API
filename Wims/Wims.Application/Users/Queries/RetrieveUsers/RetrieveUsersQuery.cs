using ErrorOr;
using MediatR;
using Wims.Application.Users.Common;
using Wims.Domain.Entities;

namespace Wims.Application.Users.Queries.Retrieve
{
    public record RetrieveUsersQuery() : IRequest<ErrorOr<UsersResult>>;
}
