using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.DTOs;
using Wims.Domain.Entities;
using Wims.Infrastructure.Database_Access;

namespace Wims.Infrastructure.Persistance
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<ProductDTO> GetAll()
        {
            var products = _context.Products
                .Include(p => p.Category)
                .Select(x => x)
                .ToList();

            var productDTOs = products.Select(p => _mapper.Map<ProductDTO>(p)).ToList();

            return productDTOs;
        }

        public ProductDTO? GetProductDTOById(Guid Id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .FirstOrDefault(x => x.Id == Id);

            var productDTO = _mapper.Map<ProductDTO>(product);

            return productDTO;
        }

        public ProductDTO? GetProductDTOByName(string Name)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .FirstOrDefault(x => x.Name == Name);

            var productDTO = _mapper.Map<ProductDTO>(product);

            return productDTO;
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

        Product? IProductRepository.GetProductByName(string Name)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .FirstOrDefault(x => x.Name == Name);

            return product;
        }

        Product? IProductRepository.GetProductById(Guid Id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .FirstOrDefault(x => x.Id == Id);

            return product;
        }
    }
}
