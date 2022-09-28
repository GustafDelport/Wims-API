using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wims.Application.Products.Commands.Delete;
using Wims.Application.Products.Commands.Insert;
using Wims.Application.Products.Commands.Update;
using Wims.Application.Products.Common;
using Wims.Application.Products.Queries.RetrieveProduct;
using Wims.Application.Products.Queries.RetrieveProducts;
using Wims.Contracts.Product.Requests;
using Wims.Contracts.Product.Responses;

namespace Wims.Api.Controllers
{
    [Route("Product")]
    public class ProductController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public ProductController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpGet("Product")]
        public async Task<IActionResult> GetProductAsync(ProductIdRequest request)
        {
            var query = _mapper.Map<RetrieveProductQuery>(request);

            ErrorOr<ProductResult> response = await _mediator.Send(query);

            return response.Match(
                response => Ok(_mapper.Map<ProductResponse>(response)),
                errors => Problem(errors));
        }

        [HttpGet("Products")]
        public async Task<IActionResult> GetProductsAsync()
        {
            ErrorOr<ProductsResult> response = await _mediator.Send(new RetrieveProductsQuery());

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> InsertProductAsync(InsertProductRequest request)
        {
            var command = _mapper.Map<InsertProductCommand>(request);

            ErrorOr<ProductResult> response = await _mediator.Send(command);

            return response.Match(
                response => Ok(_mapper.Map<ProductResponse>(response)),
                errors => Problem(errors));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteProductAsync(ProductIdRequest request)
        {
            var command = _mapper.Map<DeleteProductCommand>(request);

            ErrorOr<ProductResult> response = await _mediator.Send(command);

            return response.Match(
                response => Ok(_mapper.Map<ProductResponse>(response)),
                errors => Problem(errors));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProductAsync(UpdateProductRequest request)
        {
            var command = _mapper.Map<UpdateProductCommand>(request);

            ErrorOr<ProductResult> response = await _mediator.Send(command);

            return response.Match(
                response => Ok(_mapper.Map<ProductResponse>(response)),
                errors => Problem(errors));
        }
    }
}
