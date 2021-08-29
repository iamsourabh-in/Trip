using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip.Profile.Application.Feature.User.Command.AddUserCommand
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(request => request).NotNull().NotEmpty().WithMessage("Invalid Request");
        }
    }
}
