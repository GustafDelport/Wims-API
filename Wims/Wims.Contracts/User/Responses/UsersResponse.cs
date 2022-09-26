namespace Wims.Contracts.User.Responses
{
    public record UsersResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email);
}
