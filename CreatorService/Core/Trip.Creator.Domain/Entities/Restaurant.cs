using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Trip.Domain.Common.Entities;

namespace Trip.Creator.Domain.Entities
{
    public class Restaurant : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Owner { get; set; }


        public virtual List<RestaurantOutlet> Outlets { get; set; }
    }
}
