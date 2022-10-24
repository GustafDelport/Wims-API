using ErrorOr;
using MediatR;
using Wims.Application.Common.Interfaces.Authentication;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Application.Authentication.Common;
using Wims.Domain.Common.Errors;
using Wims.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Wims.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(
            IUserRepository userRepository, 
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var hashPassword = GetHashString(command.Password);

            //Persits user to repository
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = hashPassword
            };

            _userRepository.Add(user);

            //Generate JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
