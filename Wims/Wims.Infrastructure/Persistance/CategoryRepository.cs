using Microsoft.EntityFrameworkCore;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Entities;
using Wims.Infrastructure.Database_Access;

namespace Wims.Infrastructure.Persistance
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;

        public CategoryRepository(DatabaseContext context)
        {
            _context = context;
        }

        public ICollection<Category> GetAll()
        {
            var categories = _context.Categories
                .Select(x => x)
                .ToList();

            return categories;
        }

        public Category? GetCategoryById(Guid Id)
        {
            var category = _context.Categories
                .Include(c => c.Products)
                .FirstOrDefault(c => c.Id == Id);
            
            return category;
        }

        public Category? GetCategoryByName(string Name)
        {
            var category = _context.Categories
                .Include(c => c.Products)
                .FirstOrDefault(c => c.Name == Name);

            return category;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            var entity = _context.Categories.FirstOrDefault(c => c.Id == Id);

            _context.Categories.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}
