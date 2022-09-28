using FluentValidation;

namespace Wims.Application.Products.Commands.Update
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Name)
                .MinimumLength(3).WithMessage("Product name should be atleast 3 characters long.")
                .MaximumLength(30).WithMessage("Product name should be a maximum of 20 characters.")
                .When(x => !string.IsNullOrEmpty(x.Name));

            RuleFor(x => x.Description)
                .MinimumLength(5).WithMessage("Product name should be atleast 5 characters long.")
                .MaximumLength(250).WithMessage("Product name should be a maximum of 250 characters.")
                .When(x => !string.IsNullOrEmpty(x.Name));

            RuleFor(x => x.SellingPrice)
                .GreaterThan(x => x.CostPrice).WithMessage("The Selling price should be greater than the cost price.")
                .When(x => x.SellingPrice is not 0);

            RuleFor(x => x.CostPrice)
                .GreaterThanOrEqualTo(0).WithMessage("The Cost price should not be a negative number.")
                .When(x => x.CostPrice is not 0);

            RuleFor(x => x.QtyInStock)
                .GreaterThanOrEqualTo(0).WithMessage("The Quantity in stock should not be a negative number.")
                .When(x => x.QtyInStock is not 0);

            RuleFor(x => x.CategoryName)
                .MinimumLength(3).WithMessage("Category name should be atleast 3 characters long.")
                .MaximumLength(15).WithMessage("Category name should be a maximum of 15 characters.")
                .When(x => !string.IsNullOrEmpty(x.CategoryName));
        }
    }
}
