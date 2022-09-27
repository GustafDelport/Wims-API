using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wims.Application.Categories.Commands.Insert;
using Wims.Domain.Entities;

namespace Wims.Application.Products.Commands.Insert
{
    public class InsertProductCommandValidator : AbstractValidator<InsertProductCommand>
    {
        public InsertProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name should not be empty")
                .MinimumLength(3).WithMessage("Product name should be atleast 3 characters long.")
                .MaximumLength(30).WithMessage("Product name should be a maximum of 20 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Product description should not be empty")
                .MinimumLength(5).WithMessage("Product name should be atleast 5 characters long.")
                .MaximumLength(250).WithMessage("Product name should be a maximum of 250 characters.");

            RuleFor(x => x.SellingPrice)
                .GreaterThan(x => x.CostPrice).WithMessage("The Selling price should be greater than the cost price.");

            RuleFor(x => x.CostPrice)
                .GreaterThanOrEqualTo(0).WithMessage("The Cost price should not be a negative number.");

            RuleFor(x => x.QtyInStock)
                .GreaterThanOrEqualTo(0).WithMessage("The Quantity in stock should not be a negative number.");


            RuleFor(x => x.Category.Name)
                .NotEmpty().WithMessage("Category name should not be empty")
                .MinimumLength(3).WithMessage("Category name should be atleast 3 characters long.")
                .MaximumLength(15).WithMessage("Category name should be a maximum of 15 characters.");

            RuleFor(c => c.Category.Description)
                .NotEmpty().WithMessage("Category description should not be empty")
                .MinimumLength(5).WithMessage("Category description should be atleast 5 characters long.")
                .MaximumLength(250).WithMessage("Category description should be a maximum of 250 characters.");
        }
    }
}
