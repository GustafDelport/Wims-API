using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Entities;

namespace Wims.Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public ICollection<User> GetAll()
        {
            return _users;
        }

        public User? GetUserById(Guid Id)
        {
            return _users.SingleOrDefault(u => u.Id == Id);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Delete(Guid Id)
        {
            var entity = GetUserById(Id);

            _users.Remove(entity);
        }

        public void Update(User user)
        {
            var entity = GetUserById(user.Id);

            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Email = user.Email;
            entity.Password = user.Password;

            //Temp solutions while Ef is not hooked up
            _users.Remove(entity);
            _users.Add(entity);
        }
    }
}
