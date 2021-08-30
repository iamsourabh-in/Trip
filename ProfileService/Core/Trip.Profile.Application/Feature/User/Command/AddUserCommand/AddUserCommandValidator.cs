using FluentValidation;

namespace Trip.Profile.Application.Feature.User.Command.AddUserCommand
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(request => request).NotNull().NotEmpty().WithMessage("Invalid Request");

            RuleFor(request => request.UserName).NotNull().NotEmpty().WithMessage("Invalid UserName");

            RuleFor(request => request.Email).NotNull().NotEmpty().WithMessage("Invalid Email");
        }
    }
}
