using ErrorOr;

namespace Wims.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email is Already in Use.");

            public static Error NotFound => Error.NotFound(
                code: "User.NotFound",
                description: "User Not Found");

            public static Error Conflict => Error.Conflict(
                code: "User.Conflict",
                description: "There Was an Error Processing Your Request");
        }
    }
}
