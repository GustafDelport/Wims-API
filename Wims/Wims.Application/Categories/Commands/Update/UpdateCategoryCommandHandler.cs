using ErrorOr;
using MediatR;
using Wims.Application.Categories.Common;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Common.Errors;
using Wims.Domain.Entities;

namespace Wims.Application.Categories.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ErrorOr<CategoryResult>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<CategoryResult>> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_categoryRepository.GetCategoryById(command.Id) is not Category category)
            {
                return Errors.Category.NotFound;
            }

            category.Name = string.IsNullOrEmpty(command.Name) ? category.Name : command.Name;
            category.Description = string.IsNullOrEmpty(command.Description) ? category.Description : command.Description;

            try
            {
                _categoryRepository.Update(category);
                return new CategoryResult(category, "Updated");
            }
            catch (Exception)
            {
                return Errors.Category.Conflict;
            }
        }
    }
}
