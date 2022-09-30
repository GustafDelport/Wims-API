using ErrorOr;
using MapsterMapper;
using MediatR;
using Wims.Application.Categories.Common;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Common.Errors;
using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Categories.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ErrorOr<CategoryResult>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<CategoryResult>> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_categoryRepository.GetCategoryById(command.Id) is not Category category)
            {
                return Errors.Category.NotFound;
            }

            if (_categoryRepository.GetCategoryByName(command.Name) is not null)
            {
                return Errors.Category.DuplicateCategory;
            }

            category.Name = string.IsNullOrEmpty(command.Name) ? category.Name : command.Name;
            category.Description = string.IsNullOrEmpty(command.Description) ? category.Description : command.Description;

            try
            {
                var categoryDTO = _mapper.Map<CategoryDTO>(category);
                _categoryRepository.Update(category);
                return new CategoryResult(categoryDTO, "Updated");
            }
            catch (Exception)
            {
                return Errors.Category.Conflict;
            }
        }
    }
}
