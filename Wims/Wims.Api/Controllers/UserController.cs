using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wims.Application.Users.Commands.Delete;
using Wims.Application.Users.Commands.Update;
using Wims.Application.Users.Common;
using Wims.Application.Users.Queries.Retrieve;
using Wims.Application.Users.Queries.RetrieveUser;
using Wims.Contracts.User.Requests;
using Wims.Contracts.User.Responses;

namespace Wims.Api.Controllers
{
    [Route("User")]
    public class UserController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public UserController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("User")]
        public async Task<IActionResult> GetUserAsync(UserIdRequest request)
        {
            var query = _mapper.Map<RetrieveUserQuery>(request);

            ErrorOr<UserResult> response = await _mediator.Send(query);

            return response.Match(
                response => Ok(_mapper.Map<UserResponse>(response)),
                errors => Problem(errors));
        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetUsersAsync()
        {
            ErrorOr<UsersResult> response = await _mediator.Send(new RetrieveUsersQuery());

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUserAsync(UserIdRequest request)
        {
            var command = _mapper.Map<DeleteUserCommand>(request);

            ErrorOr<UserResult> response = await _mediator.Send(command);

            return response.Match(
                response => Ok(_mapper.Map<UserResponse>(response)),
                errors => Problem(errors));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUserAsync(UpdateUserRequest request)
        {
            var command = _mapper.Map<UpdateUserCommand>(request);

            ErrorOr<UserResult> response = await _mediator.Send(command);

            return response.Match(
                response => Ok(_mapper.Map<UserResponse>(response)),
                errors => Problem(errors));
        }
    }
}
