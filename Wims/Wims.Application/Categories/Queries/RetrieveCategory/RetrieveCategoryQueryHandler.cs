using ErrorOr;
using MapsterMapper;
using MediatR;
using Wims.Application.Categories.Common;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Common.Errors;
using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Categories.Queries.RetrieveCategory
{
    public class RetrieveCategoryQueryHandler : IRequestHandler<RetrieveCategoryQuery, ErrorOr<CategoryResult>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public RetrieveCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<CategoryResult>> Handle(RetrieveCategoryQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_categoryRepository.GetCategoryById(query.Id) is not Category category)
            {
                return Errors.Category.NotFound;
            }

            return new CategoryResult(_mapper.Map<CategoryDTO>(category), "Retrieved");
        }
    }
}
