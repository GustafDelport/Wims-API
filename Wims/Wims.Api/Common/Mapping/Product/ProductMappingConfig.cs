using Mapster;
using Wims.Application.Products.Commands.Insert;
using Wims.Application.Products.Common;
using Wims.Contracts.Product.Requests;
using Wims.Contracts.Product.Responses;

namespace Wims.Api.Common.Mapping.Product
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProductsResult, ProductsResponse>()
                .Map(dest => dest, src => src.Products);
        }
    }
}
