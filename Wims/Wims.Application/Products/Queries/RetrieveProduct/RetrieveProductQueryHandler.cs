using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Application.Products.Common;
using Wims.Domain.Common.Errors;
using Wims.Domain.Entities;

namespace Wims.Application.Products.Queries.RetrieveProduct
{
    public class RetrieveProductQueryHandler : IRequestHandler<RetrieveProductQuery, ErrorOr<ProductResult>>
    {
        private readonly IProductRepository _productRepository;

        public RetrieveProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ErrorOr<ProductResult>> Handle(RetrieveProductQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_productRepository.GetProductById(query.Id) is not Product product)
            {
                return Errors.Product.NotFound;
            }

            return new ProductResult(product, "Retrieved");
        }
    }
}
