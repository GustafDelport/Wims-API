using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wims.Domain.Entities;

namespace Wims.Application.Common.Interfaces.Persistance
{
    public interface IProductRepository
    {
        Product? GetProductByName(string Name);
        Product? GetProductById(Guid Id);
        ICollection<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Guid Id);
    }
}
