using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wims.Contracts.User.Responses
{
    public record UserResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Result);
}
