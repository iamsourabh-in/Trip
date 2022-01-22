using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trip.Domain.Common.Entities;

namespace Trip.Creator.Domain.Entities
{
    public class RestaurantOutlet : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public DateTime Established { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime OpensAt { get; set; }

        [Required]
        public DateTime ClosesAt { get; set; }

        public virtual Restaurant Restaurant { get; set; }

    }
}
