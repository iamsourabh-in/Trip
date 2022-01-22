using System.ComponentModel.DataAnnotations;
using Trip.Domain.Common.Entities;

namespace Trip.Creator.Domain.Entities
{
    public  class FoodTable : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Area { get; set; }

        [Required]
        public int Sitting { get; set; }

        public RestaurantOutlet RestaurantOutlet { get; set; }  
    }
}
