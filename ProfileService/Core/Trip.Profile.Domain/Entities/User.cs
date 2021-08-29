using System;
using System.ComponentModel.DataAnnotations;
using Trip.Profile.Domain.Base;

namespace Trip.Profile.Domain.Entities
{
    public class User : Entity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public bool Active { get; set; }

        public bool Approved { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
