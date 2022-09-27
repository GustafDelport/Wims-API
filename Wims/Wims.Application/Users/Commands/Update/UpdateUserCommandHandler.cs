using ErrorOr;
using MediatR;
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

            user.FirstName = string.IsNullOrEmpty(command.FirstName) ? user.FirstName : command.FirstName; 
            user.LastName = string.IsNullOrEmpty(command.LastName) ? user.LastName : command.LastName;
            user.Password = string.IsNullOrEmpty(command.Password) ? user.Password : command.Password;
            user.Email = string.IsNullOrEmpty(command.Email) ? user.Email : command.Email;

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
