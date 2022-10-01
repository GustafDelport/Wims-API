using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Users.Common
{
    public record UsersResult(
        ICollection<UserDTO> Users);
}
