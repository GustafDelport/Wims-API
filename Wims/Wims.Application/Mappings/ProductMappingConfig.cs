using Mapster;
using MapsterMapper;
using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Mappings
{
    public class ProductMappingConfig : IRegister
    {
        private readonly IMapper _mapper;

        public ProductMappingConfig(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Product, ProductDTO>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.SellingPrice, src => src.SellingPrice)
                .Map(dest => dest.CostPrice, src => src.CostPrice)
                .Map(dest => dest.QtyInStock, src => src.QtyInStock)
                .Map(dest => dest.MinThreshold, src => src.MinThreshold)
                .Map(dest => dest.Category, src => _mapper.Map<CategoryDTO>(src.Category));
        }
    }
}
