using ErrorOr;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Application.Products.Common;
using Wims.Domain.Common.Errors;
using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Products.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ErrorOr<ProductResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ProductResult>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_productRepository.GetProductById(command.Id) is not Product product)
            {
                return Errors.Product.NotFound;
            }
            else
            {
                try
                {
                    var productDTO = _mapper.Map<ProductDTO>(product);

                    _productRepository.Delete(product.Id);
                    return new ProductResult(productDTO, "Deleted");
                }
                catch (Exception)
                {
                    return Errors.Product.Conflict;
                }
            }
        }
    }
}
