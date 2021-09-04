using Microsoft.AspNetCore.Identity;

namespace Trip.Identity.Persistence.Data
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
    }
}
