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
            return (ICollection<Category>)_context.Categories.Select(x => x);
        }

        public Category? GetCategoryById(Guid Id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == Id);
        }

        public Category? GetCategoryByName(string name)
        {
            return _context.Categories.FirstOrDefault(c => c.Name == name);
        }

        public void Add(Category category)
        {
            _context.Categories.AddAsync(category);
        }

        public void Delete(Guid Id)
        {
            var entity = _context.Categories.FirstOrDefault(c => c.Id == Id);

            _context.Categories.Remove(entity);
        }

        public void Update(Category category)
        {
            //var entity = _context.Categories.FirstOrDefault(c => c.Id == category.Id);

            //entity.Name = category.Name;
            //entity.Description = category.Description;

            _context.Categories.Update(category);
        }
    }
}
