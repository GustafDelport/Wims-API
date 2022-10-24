using FluentValidation;

namespace Wims.Application.Categories.Commands.Insert
{
    public class InsertCategoryCommandValidator : AbstractValidator<InsertCategoryCommand>
    {
        public InsertCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name should not be empty")
                .MinimumLength(3).WithMessage("Category name should be atleast 3 characters long.")
                .MaximumLength(15).WithMessage("Category name should be a maximum of 15 characters.");


            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Category description should not be empty")
                .MinimumLength(5).WithMessage("Category description should be atleast 5 characters long.")
                .MaximumLength(250).WithMessage("Category description should be a maximum of 250 characters.");
        }
    }
}
