namespace Wims.Contracts.Product.Requests
{
    public record UpdateProductRequest(
        Guid Id,
        string? Name,
        string? Description,
        double? SellingPrice,
        double? CostPrice,
        int? QtyInStock,
        string? CategoryName,
        int? MinThreshold);
}
