namespace Wims.Contracts.Product.Responses
{
    public record ProductsResponse(Guid Id,
        string Name,
        string Description,
        double SellingPrice,
        double CostPrice,
        int QtyInStock,

        Guid CategoryId,
        string CategoryName,
        string CategoryDescription);
}
