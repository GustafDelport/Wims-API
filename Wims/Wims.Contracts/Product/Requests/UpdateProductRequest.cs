using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wims.Contracts.Product.Requests
{
    public record UpdateProductRequest(
        Guid Id,
        string? Name,
        string? Description,
        double? SellingPrice,
        double? CostPrice,
        int? QtyInStock,
        string? CategoryName,
        int? MinThreshold);
}
