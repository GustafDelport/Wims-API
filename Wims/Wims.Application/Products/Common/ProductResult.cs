using Wims.Domain.Entities;

namespace Wims.Application.Products.Common
{
    public record ProductResult(
        Product Product,
        string? Result);
}
