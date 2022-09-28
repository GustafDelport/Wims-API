using ErrorOr;
using MediatR;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Application.Users.Common;
using Wims.Domain.Common.Errors;
using Wims.Domain.Entities;

namespace Wims.Application.Users.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<UserResult>>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<UserResult>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_userRepository.GetUserById(command.Id) is not User user)
            {
                return Errors.User.NotFound;
            }

            else
            {
                try
                {
                    var temp = user;

                    _userRepository.Delete(command.Id);
                    return new UserResult(temp, "Deleted");
                }
                catch (Exception)
                {
                    return Errors.User.Conflict;
                }
            }
        }
    }
}
