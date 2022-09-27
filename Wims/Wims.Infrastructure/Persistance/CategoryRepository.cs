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
            var entity = GetCategoryById(Id);
            _categories.Remove(entity);
        }

        public void Update(Category category)
        {
            var entity = GetCategoryById(category.Id);

            entity.Name = category.Name;
            entity.Description = category.Description;

            //Temp solutions while Ef is not hooked up
            _categories.Remove(entity);
            _categories.Add(entity);
        }
    }
}
