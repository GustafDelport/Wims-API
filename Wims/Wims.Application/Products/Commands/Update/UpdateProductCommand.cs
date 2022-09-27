using ErrorOr;
using MediatR;
using Wims.Application.Products.Common;
using Wims.Domain.Entities;

namespace Wims.Application.Products.Commands.Update
{
    public record UpdateProductCommand(
        Guid Id,
        string Name,
        string Description,
        double SellingPrice,
        double CostPrice,
        int QtyInStock,
        Category Category) : IRequest<ErrorOr<ProductResult>>;
}
