using ErrorOr;
using MediatR;
using Wims.Application.Products.Common;
using Wims.Domain.Entities;

namespace Wims.Application.Products.Commands.Insert
{
    public record InsertProductCommand(
        string Name,
        string Description,
        double SellingPrice,
        double CostPrice,
        int QtyInStock,
        int MinThreshold,
        string CategoryName) : IRequest<ErrorOr<ProductResult>>;
}
