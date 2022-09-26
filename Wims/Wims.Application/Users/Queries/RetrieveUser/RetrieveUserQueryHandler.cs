using ErrorOr;
using MediatR;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Application.Users.Common;
using Wims.Domain.Common.Errors;
using Wims.Domain.Entities;

namespace Wims.Application.Users.Queries.RetrieveUser
{
    public class RetrieveUserQueryHandler : IRequestHandler<RetrieveUserQuery, ErrorOr<UserResult>>
    {
        private readonly IUserRepository _userRepository;

        public RetrieveUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<UserResult>> Handle(RetrieveUserQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_userRepository.GetUserById(query.Id) is not User user)
            {
                return Errors.User.NotFound;
            }

            return new UserResult(user, "Retrieved");
        }
    }
}
