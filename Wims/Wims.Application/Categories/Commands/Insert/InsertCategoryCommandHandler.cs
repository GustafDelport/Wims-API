using ErrorOr;
using MapsterMapper;
using MediatR;
using Wims.Application.Categories.Common;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Common.Errors;
using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Categories.Commands.Insert
{
    public class InsertCategoryCommandHandler : IRequestHandler<InsertCategoryCommand, ErrorOr<CategoryResult>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public InsertCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<CategoryResult>> Handle(InsertCategoryCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_categoryRepository.GetCategoryByName(command.Name) is not null)
            {
                return Errors.Category.DuplicateCategory;
            }

            var category = new Category
            {
                Name = command.Name,
                Description = command.Description,
                MinThreshold = command.MinThreshold
            };

            var categoryDTO = _mapper.Map<CategoryDTO>(category);

            try
            {
                _categoryRepository.Add(category);
                return new CategoryResult(categoryDTO, "Inserted");
            }
            catch (Exception)
            {

                return Errors.Category.Conflict;
            }
        }
    }
}
