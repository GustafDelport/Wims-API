namespace Wims.Contracts.Category.Requests
{
    public record UpdateCategoryRequest(
        Guid id,
        string? Name,
        string? Description,
        int? MinThreshold);
}
