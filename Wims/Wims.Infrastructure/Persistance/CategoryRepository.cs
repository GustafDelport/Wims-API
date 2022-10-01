using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.DTOs;
using Wims.Domain.Entities;
using Wims.Infrastructure.Database_Access;

namespace Wims.Infrastructure.Persistance
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<CategoryDTO> GetAll()
        {
            var categories = _context.Categories
                .Select(x => x)
                .ToList();

            var categoryDTOs = categories.Select(x => _mapper.Map<CategoryDTO>(x)).ToList();

            return categoryDTOs;
        }

        public CategoryDTO? GetCategoryDTOById(Guid Id)
        {
            var category = _context.Categories
                .FirstOrDefault(c => c.Id == Id);

            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            
            return categoryDTO;
        }

        public CategoryDTO? GetCategoryDTOByName(string Name)
        {
            var category = _context.Categories
                .FirstOrDefault(c => c.Name == Name);

            var categoryDTO = _mapper.Map<CategoryDTO>(category);

            return categoryDTO;
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

        Category? ICategoryRepository.GetCategoryByName(string name)
        {
            var category = _context.Categories
                .FirstOrDefault(c => c.Name == name);

            return category;
        }

        Category? ICategoryRepository.GetCategoryById(Guid Id)
        {
            var category = _context.Categories
                .FirstOrDefault(c => c.Id == Id);

            return category;
        }
    }
}
