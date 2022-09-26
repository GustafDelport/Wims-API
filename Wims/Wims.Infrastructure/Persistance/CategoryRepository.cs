using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Entities;

namespace Wims.Infrastructure.Persistance
{
    public class CategoryRepository : ICategoryRepository
    {
        public Category? GetCategoryById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Category? GetCategoryByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Add(Category category)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
