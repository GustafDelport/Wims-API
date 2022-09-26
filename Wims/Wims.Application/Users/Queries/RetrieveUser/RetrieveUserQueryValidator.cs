using FluentValidation;

namespace Wims.Application.Users.Queries.RetrieveUser
{
    public class RetrieveUserQueryValidator : AbstractValidator<RetrieveUserQuery>
    {
        public RetrieveUserQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
