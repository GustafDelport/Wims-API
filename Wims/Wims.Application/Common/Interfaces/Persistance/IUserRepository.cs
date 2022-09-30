using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        UserDTO? GetUserDTOByEmail(string email);
        UserDTO? GetUserDTOById(Guid Id);
        User? GetUserByEmail(string email);
        User? GetUserById(Guid Id);
        ICollection<UserDTO> GetAll();
        void Add(User user);
        void Update(User user);
        void Delete(Guid Id);
    }
}
