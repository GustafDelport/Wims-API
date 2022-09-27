using ErrorOr;
using MediatR;
using Wims.Application.Categories.Common;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Common.Errors;
using Wims.Domain.Entities;

namespace Wims.Application.Categories.Queries.RetrieveCategory
{
    public class RetrieveCategoryQueryHandler : IRequestHandler<RetrieveCategoryQuery, ErrorOr<CategoryResult>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public RetrieveCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<CategoryResult>> Handle(RetrieveCategoryQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_categoryRepository.GetCategoryById(query.Id) is not Category category)
            {
                return Errors.Category.NotFound;
            }

            return new CategoryResult(category, "Retrieved");
        }
    }
}
