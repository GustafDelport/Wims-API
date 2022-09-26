using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Entities;

namespace Wims.Infrastructure.Persistance
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> _products = new();

        public ICollection<Product> GetAll()
        {
            return _products;
        }

        public Product? GetProductById(Guid Id)
        {
            return _products.FirstOrDefault(p => p.Id == Id);
        }

        public Product? GetProductByName(string Name)
        {
            return _products.FirstOrDefault(p => p.Name == Name);
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Guid Id)
        {
            _products.Remove(GetProductById(Id));
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
