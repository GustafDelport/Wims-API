using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Entities;

namespace Wims.Infrastructure.Persistance
{
    public class CategoryRepository : ICategoryRepository
    {
        private static readonly List<Category> _categories = new();

        public ICollection<Category> GetAll()
        {
            return _categories;
        }

        public Category? GetCategoryById(Guid Id)
        {
            return _categories.FirstOrDefault(c => c.Id == Id);
        }

        public Category? GetCategoryByName(string name)
        {
            return _categories.FirstOrDefault(c => c.Name == name);
        }

        public void Add(Category category)
        {
            _categories.Add(category);
        }

        public void Delete(Guid Id)
        {
            _categories.Remove(GetCategoryById(Id));
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
