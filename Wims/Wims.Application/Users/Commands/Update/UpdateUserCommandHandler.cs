using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Application.Users.Common;
using Wims.Domain.Common.Errors;
using Wims.Domain.Entities;

namespace Wims.Application.Users.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ErrorOr<UserResult>>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<UserResult>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_userRepository.GetUserById(command.Id) is not User user)
            {
                return Errors.User.NotFound;
            }

            user.FirstName = !string.IsNullOrEmpty(user.FirstName) ? command.FirstName : user.FirstName; 
            user.LastName = !string.IsNullOrEmpty(user.LastName) ? command.LastName : user.LastName;
            user.Password = !string.IsNullOrEmpty(user.Password) ? command.Password : user.Password;
            user.Email = !string.IsNullOrEmpty(user.Email) ? command.Email : user.Email;

            try
            {
                _userRepository.Update(user);
                return new UserResult(user, "Updated");
            }
            catch (Exception)
            {
                return Errors.User.Conflict;
            }  
        }
    }
}
