using ErrorOr;

namespace Wims.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Product
        {
            public static Error DuplicateProduct => Error.Conflict(
                code: "Product.DuplicateProduct",
                description: "Product Already Exists.");

            public static Error NotFound => Error.NotFound(
                code: "Product.NotFound",
                description: "Product Does Not Exists.");

            public static Error Conflict => Error.Conflict(
                code: "Product.Conflict",
                description: "There Was an Error Processing Your Request");
        }
    }
    
}
