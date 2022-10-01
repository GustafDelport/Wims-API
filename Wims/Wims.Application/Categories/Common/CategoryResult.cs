using Wims.Domain.DTOs;
using Wims.Domain.Entities;

namespace Wims.Application.Categories.Common
{
    public record CategoryResult(
        CategoryDTO Category,
        string? Result);
}
