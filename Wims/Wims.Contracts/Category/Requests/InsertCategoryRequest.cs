using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wims.Contracts.Category.Requests
{
    public record InsertCategoryRequest(
        string Name,
        string Description);
}
