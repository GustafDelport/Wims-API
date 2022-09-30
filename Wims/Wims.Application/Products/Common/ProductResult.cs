using Wims.Domain.DTOs;

namespace Wims.Application.Products.Common
{
    public record ProductResult(
        ProductDTO Product,
        string? Result);
}
