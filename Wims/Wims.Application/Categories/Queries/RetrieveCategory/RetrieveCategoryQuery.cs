using ErrorOr;
using MediatR;
using Wims.Application.Categories.Common;

namespace Wims.Application.Categories.Queries.RetrieveCategory
{
    public record RetrieveCategoryQuery(
        Guid Id) : IRequest<ErrorOr<CategoryResult>>;
}
