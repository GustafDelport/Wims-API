using Mapster;
using Wims.Application.Users.Common;
using Wims.Contracts.User.Responses;

namespace Wims.Api.Common.Mapping
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserResult, UserResponse>()
                .Map(dest => dest, src => src.User);

            //config.NewConfig<UsersResult, UsersResponse>()
            //    .Map(dest => dest, src => src.Users);
        }
    }
}
