using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Users.Common
{
    public record UserResult(
        UserDTO User,
        string? Result);
}
