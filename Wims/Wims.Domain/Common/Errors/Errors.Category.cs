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

            public static Error NotFound => Error.NotFound(
                code: "Category.NotFound",
                description: "Category does not exists.");

            public static Error Conflict => Error.Conflict(
                code: "Category.Conflict",
                description: "There was an error processing your request");
        }
    }
    
}
