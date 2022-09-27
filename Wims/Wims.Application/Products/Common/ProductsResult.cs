using Wims.Domain.Entities;

namespace Wims.Application.Products.Common
{
    public record ProductsResult(
        ICollection<Product> Products);
}
