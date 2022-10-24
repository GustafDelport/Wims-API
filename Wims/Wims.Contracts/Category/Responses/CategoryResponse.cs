namespace Wims.Contracts.Category.Responses
{
    public record CategoryResponse(
        Guid Id,
        string Name,
        string Description,
        string Result);
}
