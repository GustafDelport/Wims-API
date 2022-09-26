using Wims.Domain.Entities;

namespace Wims.Application.Users.Common
{
    public record UserResult(
        User User,
        string? Result);
}
