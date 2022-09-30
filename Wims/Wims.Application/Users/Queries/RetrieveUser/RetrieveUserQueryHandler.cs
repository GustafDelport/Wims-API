using ErrorOr;
using MapsterMapper;
using MediatR;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Application.Users.Common;
using Wims.Domain.Common.Errors;
using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Users.Queries.RetrieveUser
{
    public class RetrieveUserQueryHandler : IRequestHandler<RetrieveUserQuery, ErrorOr<UserResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RetrieveUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<UserResult>> Handle(RetrieveUserQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_userRepository.GetUserById(query.Id) is not User user)
            {
                return Errors.User.NotFound;
            }

            return new UserResult(_mapper.Map<UserDTO>(user), "Retrieved");
        }
    }
}
