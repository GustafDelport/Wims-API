using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wims.Application.Products.Common;

namespace Wims.Application.Products.Commands.Delete
{
    public record DeleteProductCommand(
        Guid Id) : IRequest<ErrorOr<ProductResult>>;
}
