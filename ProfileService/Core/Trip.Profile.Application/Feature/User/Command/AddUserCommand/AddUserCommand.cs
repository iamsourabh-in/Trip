using System;
using Trip.Profile.Application.Common;

namespace Trip.Profile.Application.Feature.User.Command.AddUserCommand
{
    public class AddUserCommand : ICommand<AddUserCommandResponse>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
    }
}
