using ErrorOr;
using MediatR;
using Wims.Application.Categories.Common;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Common.Errors;

namespace Wims.Application.Categories.Queries.RetrieveCategories
{
    public class RetrieveCategoriesQueryHandler : IRequestHandler<RetrieveCategoriesQuery, ErrorOr<CategoriesResult>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public RetrieveCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<CategoriesResult>> Handle(RetrieveCategoriesQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var categories = _categoryRepository.GetAll();

            if (categories.Count == 0)
            {
                return Errors.Category.NotFound;
            }

            return new CategoriesResult(categories);
        }
    }
}
