using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wims.Application.Products.Queries.RetrieveProduct
{
    public class RetrieveProductQueryValidator : AbstractValidator<RetrieveProductQuery>
    {
        public RetrieveProductQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
