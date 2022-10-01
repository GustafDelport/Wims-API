namespace Wims.Contracts.Category.Responses
{
    public record CategoriesResponse(
        Guid Id,
        string Name,
        string Description,
        string Result);
}
