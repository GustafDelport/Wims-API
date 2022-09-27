using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wims.Application.Categories.Commands.Delete;
using Wims.Application.Categories.Commands.Insert;
using Wims.Application.Categories.Commands.Update;
using Wims.Application.Categories.Common;
using Wims.Application.Categories.Queries.RetrieveCategories;
using Wims.Application.Categories.Queries.RetrieveCategory;
using Wims.Contracts.Category.Requests;
using Wims.Contracts.Category.Responses;

namespace Wims.Api.Controllers
{
    [Route("Category")]
    public class CategoryController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CategoryController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("Category")]
        public async Task<IActionResult> GetCategoryAsync(CategoryIdRequest request)
        {
            var query = _mapper.Map<RetrieveCategoryQuery>(request);

            ErrorOr<CategoryResult> response = await _mediator.Send(query);

            return response.Match(
                response => Ok(_mapper.Map<CategoryResponse>(response)),
                errors => Problem(errors));
        }

        [HttpGet("Categories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            ErrorOr<CategoriesResult> response = await _mediator.Send(new RetrieveCategoriesQuery());

            return response.Match(
                response => Ok(_mapper.Map<CategoryResponse>(response)),
                errors => Problem(errors));
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> InsertCategoryAsync(InsertRequest request)
        {
            var command = _mapper.Map<InsertCategoryCommand>(request);

            ErrorOr<CategoryResult> response = await _mediator.Send(command);

            return response.Match(
                response => Ok(_mapper.Map<CategoryResponse>(response)),
                errors => Problem(errors));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUserAsync(CategoryIdRequest request)
        {
            var command = _mapper.Map<DeleteCategoryCommand>(request);

            ErrorOr<CategoryResult> response = await _mediator.Send(command);

            return response.Match(
                response => Ok(_mapper.Map<CategoryResponse>(response)),
                errors => Problem(errors));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryRequest request)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(request);

            ErrorOr<CategoryResult> response = await _mediator.Send(command);

            return response.Match(
                response => Ok(_mapper.Map<CategoryResponse>(response)),
                errors => Problem(errors));
        }
    }
}
