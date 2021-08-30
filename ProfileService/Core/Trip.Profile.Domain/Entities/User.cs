using System;
using System.ComponentModel.DataAnnotations;

namespace Trip.Profile.Domain.Entities
{
    public class User 
    {
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public bool Active { get; set; } = true;

        public bool Approved { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }
}
