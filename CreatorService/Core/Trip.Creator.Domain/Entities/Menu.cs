using System.ComponentModel.DataAnnotations;
using Trip.Domain.Common.Entities;

namespace Trip.Creator.Domain.Entities
{
    public class Menu : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
