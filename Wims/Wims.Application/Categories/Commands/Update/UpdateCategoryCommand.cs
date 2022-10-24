using ErrorOr;
using MediatR;
using Wims.Application.Categories.Common;

namespace Wims.Application.Categories.Commands.Update
{
    public record UpdateCategoryCommand(
        Guid Id,
        string Name,
        string Description) : IRequest<ErrorOr<CategoryResult>>;
}
