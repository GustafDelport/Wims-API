using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wims.Domain.Entities;

namespace Wims.Application.Common.Interfaces.Persistance
{
    public interface ICategoryRepository
    {
        Category? GetCategoryByName(string name);
        Category? GetCategoryById(Guid Id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
