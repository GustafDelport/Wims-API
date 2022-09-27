using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wims.Application.Categories.Commands.Update
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3).WithMessage("Category name should be atleast 3 characters long.")
                .MaximumLength(15).WithMessage("Category name should be a maximum of 15 characters.")
                .When(x => !string.IsNullOrEmpty(x.Name));

            RuleFor(x => x.Description)
                .MinimumLength(5).WithMessage("Category description should be atleast 5 characters long.")
                .MaximumLength(250).WithMessage("Category description should be a maximum of 250 characters.")
                .When(x => !string.IsNullOrEmpty(x.Description));
        }
    }
}
