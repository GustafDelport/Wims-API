using Wims.Domain.Entities;

namespace Wims.Application.Categories.Common
{
    public record CategoryResult(
        Category Category,
        string? Result);
}
