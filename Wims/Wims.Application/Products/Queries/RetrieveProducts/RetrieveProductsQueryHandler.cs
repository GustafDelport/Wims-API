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

namespace Wims.Application.Products.Queries.RetrieveProducts
{
    public class RetrieveProductsQueryHandler : IRequestHandler<RetrieveProductsQuery, ErrorOr<ProductsResult>>
    {
        private readonly IProductRepository _productRepository;

        public RetrieveProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ErrorOr<ProductsResult>> Handle(RetrieveProductsQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var products = _productRepository.GetAll();

            if (products.Count == 0)
            {
                return Errors.Product.NotFound;
            }


            return new ProductsResult(products);
        }
    }
}
