using System.ComponentModel.DataAnnotations;

namespace Trip.Identity.Areas.Admin.Models.Accounts
{
    public class AdminLoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}
