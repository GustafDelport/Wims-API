using MapsterMapper;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.DTOs;
using Wims.Domain.Entities;
using Wims.Infrastructure.Database_Access;
using static Wims.Domain.Common.Errors.Errors;
using User = Wims.Domain.Entities.User;

namespace Wims.Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<UserDTO> GetAll()
        {
            var users = _context.Users
            .Select(x => x)
            .ToList();

            var usersDTOs = users.Select(u => _mapper.Map<UserDTO>(u)).ToList();

            return usersDTOs;
        }

        public UserDTO GetUserDTOById(Guid Id)
        {
            var user = _context.Users
                .SingleOrDefault(u => u.Id == Id);

            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public UserDTO GetUserDTOByEmail(string email)
        {
            var user = _context.Users
                .SingleOrDefault(u => u.Email == email);

            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
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

        User? IUserRepository.GetUserByEmail(string email)
        {
            var user = _context.Users
                .SingleOrDefault(u => u.Email == email);

            return user;
        }

        User? IUserRepository.GetUserById(Guid Id)
        {
            var user = _context.Users
                .SingleOrDefault(u => u.Id == Id);

            return user;
        }
    }
}
