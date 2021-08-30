using System.ComponentModel.DataAnnotations;

namespace Trip.Identity.Quickstart.Account
{
    public class RegisterInputModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Gender { get; set; }

        public string ReturnUrl { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        public string PhoneNumber { get; set; }
    }

}

