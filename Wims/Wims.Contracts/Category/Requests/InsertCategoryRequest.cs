namespace Wims.Contracts.Category.Requests
{
    public record InsertCategoryRequest(
        string Name,
        string Description);
}
