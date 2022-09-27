using Mapster;
using Wims.Application.Products.Common;
using Wims.Contracts.Product.Responses;

namespace Wims.Api.Common.Mapping.Product
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProductResult, ProductResponse>()
                .Map(dest => dest, src => src.Product)
                .Map(dest => dest.CategoryId, src => src.Product.Category.Id)
                .Map(dest => dest.CategoryName, src => src.Product.Category.Name)
                .Map(dest => dest.CategoryDescription, src => src.Product.Category.Description);

            //Figure out how the mappings work
        }
    }
}
