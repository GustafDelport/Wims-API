using Wims.Domain.Entities;

namespace Wims.Application.Users.Common
{
    public record UsersResult(
        ICollection<User> Users);
}
