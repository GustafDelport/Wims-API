using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wims.Domain.Entities;

namespace Wims.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        Domain.Entities.User? GetUserByEmail(string email);
        Domain.Entities.User? GetUserById(Guid Id);
        ICollection<Domain.Entities.User> GetAll();
        void Add(Domain.Entities.User user);
        void Update(Domain.Entities.User user);
        void Delete(Guid Id);
    }
}
