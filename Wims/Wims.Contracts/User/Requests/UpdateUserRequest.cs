namespace Wims.Contracts.User.Requests
{
    public record UpdateUserRequest(
        Guid Id,
        string? FirstName,
        string? LastName,
        string? Email,
        string? Password);
}
