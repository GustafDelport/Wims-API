using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wims.Application.Categories.Common;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Common.Errors;
using Wims.Domain.Entities;

namespace Wims.Application.Categories.Commands.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ErrorOr<CategoryResult>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<CategoryResult>> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_categoryRepository.GetCategoryById(command.Id) is not Category category)
            {
                return Errors.Category.NotFound;
            }
            else
            {
                try
                {
                    var temp = category;

                    _categoryRepository.Delete(command.Id);
                    return new CategoryResult(temp, "Deleted");
                }
                catch (Exception)
                { 
                    return Errors.Category.Conflict;
                }
            }
        }
    }
}
