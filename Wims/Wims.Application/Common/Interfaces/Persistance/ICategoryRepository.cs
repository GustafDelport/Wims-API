using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Common.Interfaces.Persistance
{
    public interface ICategoryRepository
    {
        CategoryDTO? GetCategoryDTOByName(string name);
        CategoryDTO? GetCategoryDTOById(Guid Id);
        Category? GetCategoryByName(string name);
        Category? GetCategoryById(Guid Id);
        ICollection<CategoryDTO> GetAll();
        void Add(Category category);
        void Update(Category category);
        void Delete(Guid Id);
    }
}
