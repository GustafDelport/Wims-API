using ErrorOr;

namespace Wims.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Product
        {
            public static Error DuplicateProduct => Error.Conflict(
                code: "Product.DuplicateProduct",
                description: "Product already exists.");
        }
    }
    
}
