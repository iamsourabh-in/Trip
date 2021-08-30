using FluentValidation;

namespace Trip.Profile.Application.Feature.User.Queries.GetUserQuery
{
    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(request => request).NotNull().NotEmpty().WithMessage("Invalid Request");
        }
    }
}
