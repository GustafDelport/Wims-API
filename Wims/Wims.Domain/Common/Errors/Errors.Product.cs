﻿using ErrorOr;

namespace Wims.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Product
        {
            public static Error DuplicateProduct => Error.Conflict(
                code: "Product.DuplicateProduct",
                description: "Product already exists.");

            public static Error NotFound => Error.NotFound(
                code: "Product.NotFound",
                description: "Product does not exists.");

            public static Error Conflict => Error.Conflict(
                code: "Product.Conflict",
                description: "There was an error processing your request");
        }
    }
    
}
