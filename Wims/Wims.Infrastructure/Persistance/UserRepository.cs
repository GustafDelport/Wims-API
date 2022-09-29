using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Entities;
using Wims.Infrastructure.Database_Access;

namespace Wims.Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.Select(x => x).ToList();
        }

        public User GetUserById(Guid Id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == Id);
        }

        public User GetUserByEmail(string email)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == email);
            return user;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            var entity = _context.Users.SingleOrDefault(u => u.Id == Id);

            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
