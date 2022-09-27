using Wims.Domain.Entities;

namespace Wims.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        User? GetUserById(Guid Id);
        ICollection<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Delete(Guid Id);
    }
}
