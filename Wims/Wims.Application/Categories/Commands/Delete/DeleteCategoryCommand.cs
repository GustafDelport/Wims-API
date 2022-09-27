using ErrorOr;
using MediatR;
using Wims.Application.Categories.Common;

namespace Wims.Application.Categories.Commands.Delete
{
    public record DeleteCategoryCommand(
        Guid Id) : IRequest<ErrorOr<CategoryResult>>;
}
