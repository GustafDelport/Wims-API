using Wims.Domain.Entities;

namespace Wims.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Domain.Entities.User user);
    }
}
