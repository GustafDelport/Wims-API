using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wims.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Category
        {
            public static Error DuplicateCategory => Error.Conflict(
                code: "Category.DuplicateCategory",
                description: "Category already exists.");
        }
    }
    
}
