using ErrorOr;
using MapsterMapper;
using MediatR;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Application.Products.Common;
using Wims.Domain.Common.Errors;
using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Products.Queries.RetrieveProduct
{
    public class RetrieveProductQueryHandler : IRequestHandler<RetrieveProductQuery, ErrorOr<ProductResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public RetrieveProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ProductResult>> Handle(RetrieveProductQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_productRepository.GetProductById(query.Id) is not Product product)
            {
                return Errors.Product.NotFound;
            }

            return new ProductResult(_mapper.Map<ProductDTO>(product), "Retrieved");
        }
    }
}
