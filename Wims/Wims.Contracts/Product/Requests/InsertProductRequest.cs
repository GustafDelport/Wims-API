namespace Wims.Contracts.Product.Requests
{
    public record InsertProductRequest(
        string Name,
        string Description,
        double SellingPrice,
        double CostPrice,
        int QtyInStock,
        string CategoryName,
        int MinThreshold);
}
