using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wims.Contracts.User.Requests
{
    public record UserIdRequest(
        Guid Id);
}
