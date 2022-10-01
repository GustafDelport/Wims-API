using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Categories.Common
{
    public record CategoriesResult(
        ICollection<CategoryDTO> Categories);
}
