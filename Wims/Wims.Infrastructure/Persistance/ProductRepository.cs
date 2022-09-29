using Microsoft.EntityFrameworkCore;
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
            var products = _context.Products
                .Include(p => p.Category)
                .Select(x => x)
                .ToList();

            return products;
        }

        public Product? GetProductById(Guid Id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .FirstOrDefault(x => x.Id == Id);

            return product;
        }

        public Product? GetProductByName(string Name)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .FirstOrDefault(x => x.Name == Name);

            return product;
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
