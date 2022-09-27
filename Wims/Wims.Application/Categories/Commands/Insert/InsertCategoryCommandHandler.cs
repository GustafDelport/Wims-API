using ErrorOr;
using MediatR;
using Wims.Application.Categories.Common;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Common.Errors;
using Wims.Domain.Entities;

namespace Wims.Application.Categories.Commands.Insert
{
    public class InsertCategoryCommandHandler : IRequestHandler<InsertCategoryCommand, ErrorOr<CategoryResult>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public InsertCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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
                Description = command.Description
            };

            try
            {
                _categoryRepository.Add(category);
            }
            catch (Exception)
            {

                return Errors.Category.Conflict;
            }
            
            return new CategoryResult(category, "Inserted");
        }
    }
}
