using ErrorOr;
using MapsterMapper;
using MediatR;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Application.Users.Common;
using Wims.Domain.Common.Errors;
using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Users.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<UserResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
                    var userDTO = _mapper.Map<UserDTO>(user);

                    _userRepository.Delete(command.Id);
                    return new UserResult(userDTO, "Deleted");
                }
                catch (Exception)
                {
                    return Errors.User.Conflict;
                }
            }
        }
    }
}
