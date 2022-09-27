using FluentValidation;

namespace Wims.Application.Categories.Queries.RetrieveCategory
{
    public class RetrieveCategoryQueryValidator : AbstractValidator<RetrieveCategoryQuery>
    {
        public RetrieveCategoryQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
