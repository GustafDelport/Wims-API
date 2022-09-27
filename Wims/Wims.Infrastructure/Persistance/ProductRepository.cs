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
            var entity = GetProductById(Id);
            _products.Remove(entity);
        }

        public void Update(Product product)
        {
            var entity = GetProductById(product.Id);

            entity.Name = product.Name;
            entity.Description = product.Description;
            entity.CostPrice = product.CostPrice;
            entity.SellingPrice = product.SellingPrice;
            entity.QtyInStock = product.QtyInStock;
            entity.Category = product.Category;

            //Temp solutions while Ef is not hooked up
            _products.Remove(entity);
            _products.Add(entity);
        }
    }
}
