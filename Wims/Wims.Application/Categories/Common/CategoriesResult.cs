using Wims.Domain.Entities;

namespace Wims.Application.Categories.Common
{
    public record CategoriesResult(
        ICollection<Category> Categories);
}
