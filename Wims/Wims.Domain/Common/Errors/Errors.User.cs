using ErrorOr;

namespace Wims.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email is already in use.");

            public static Error NotFound => Error.NotFound(
                code: "User.NotFound",
                description: "User not found");

            public static Error Conflict => Error.Conflict(
                code: "User.Conflict",
                description: "There was an error processing your request");
        }
    }
}
