using ErrorOr;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wims.Application.Categories.Common;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Common.Errors;
using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Categories.Commands.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ErrorOr<CategoryResult>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
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
                    var categoryDTO = _mapper.Map<CategoryDTO>(category);

                    _categoryRepository.Delete(command.Id);
                    return new CategoryResult(categoryDTO, "Deleted");
                }
                catch (Exception)
                { 
                    return Errors.Category.Conflict;
                }
            }
        }
    }
}
