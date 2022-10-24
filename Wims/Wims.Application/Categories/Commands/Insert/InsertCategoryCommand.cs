using ErrorOr;
using MediatR;
using Wims.Application.Categories.Common;

namespace Wims.Application.Categories.Commands.Insert
{
    public record InsertCategoryCommand(
        string Name,
        string Description) : IRequest<ErrorOr<CategoryResult>>;
}
