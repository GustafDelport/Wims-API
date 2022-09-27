using ErrorOr;
using MediatR;
using Wims.Application.Categories.Common;

namespace Wims.Application.Categories.Queries.RetrieveCategories
{
    public record RetrieveCategoriesQuery() : IRequest<ErrorOr<CategoriesResult>>;
}
