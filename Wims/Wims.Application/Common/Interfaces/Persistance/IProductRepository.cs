using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Common.Interfaces.Persistance
{
    public interface IProductRepository
    {
        ProductDTO? GetProductDTOByName(string Name);
        ProductDTO? GetProductDTOById(Guid Id);
        Product? GetProductByName(string Name);
        Product? GetProductById(Guid Id);
        ICollection<ProductDTO> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Guid Id);
    }
}
