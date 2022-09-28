using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wims.Application.Products.Common;

namespace Wims.Application.Products.Queries.RetrieveProducts
{
    public record RetrieveProductsQuery() : IRequest<ErrorOr<ProductsResult>>;
}
