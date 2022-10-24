namespace Wims.Contracts.User.Responses
{
    public record UserResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Result);
}
