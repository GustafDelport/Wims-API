using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wims.Application.Categories.Common;

namespace Wims.Application.Categories.Commands.Update
{
    public record UpdateCategoryCommand(
        Guid Id,
        string Name,
        string Description) : IRequest<ErrorOr<CategoryResult>>;
}
