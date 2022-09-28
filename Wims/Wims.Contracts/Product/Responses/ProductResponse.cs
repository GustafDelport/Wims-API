namespace Wims.Contracts.Product.Responses
{
    public record ProductResponse(
        Guid Id,
        string Name,
        string Description,
        double SellingPrice,
        double CostPrice,
        int QtyInStock,

        Guid CategoryId,
        string CategoryName,
        string CategoryDescription);
}
