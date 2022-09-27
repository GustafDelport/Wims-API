using Mapster;
using Wims.Application.Categories.Common;
using Wims.Contracts.Category.Responses;

namespace Wims.Api.Common.Mapping.Category
{
    public class CategoryMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CategoryResult, CategoryResponse>()
                .Map(dest => dest, src => src.Category);
        }
    }
}
