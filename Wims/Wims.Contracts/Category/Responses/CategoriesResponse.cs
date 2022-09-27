using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wims.Contracts.Category.Responses
{
    public record CategoriesResponse(
        Guid Id,
        string Name,
        string Description,
        string Result);
}
