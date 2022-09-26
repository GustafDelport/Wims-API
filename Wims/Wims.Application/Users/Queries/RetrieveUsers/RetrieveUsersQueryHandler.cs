using ErrorOr;
using MediatR;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Application.Users.Common;
using Wims.Domain.Common.Errors;

namespace Wims.Application.Users.Queries.Retrieve
{
    public class RetrieveUsersQueryHandler : IRequestHandler<RetrieveUsersQuery, ErrorOr<UsersResult>>
    {
        private readonly IUserRepository _userRepository;

        public RetrieveUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<UsersResult>> Handle(RetrieveUsersQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var users = _userRepository.GetAll();

            if (users.Count == 0)
            {
                return Errors.User.NotFound;
            }

            return new UsersResult(users);
        }
    }
}
