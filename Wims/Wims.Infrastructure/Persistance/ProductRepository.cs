using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Entities;

namespace Wims.Infrastructure.Persistance
{
    public class ProductRepository : IProductRepository
    {
        public Product? GetProductById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Product? GetProductByName(string Name)
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
