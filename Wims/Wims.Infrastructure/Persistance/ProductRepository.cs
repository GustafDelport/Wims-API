using System.Xml.Linq;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Entities;
using Wims.Infrastructure.Database_Access;

namespace Wims.Infrastructure.Persistance
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        public ICollection<Product> GetAll()
        {
            return _context.Products.Select(x => x).ToList();
        }

        public Product? GetProductById(Guid Id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == Id);
        }

        public Product? GetProductByName(string Name)
        {
            return _context.Products.FirstOrDefault(p => p.Name == Name);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            var entity = _context.Products.FirstOrDefault(p => p.Id == Id);
            _context.Products.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
