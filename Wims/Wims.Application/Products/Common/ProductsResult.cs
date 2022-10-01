using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Products.Common
{
    public record ProductsResult(
        ICollection<ProductDTO> Products);
}
