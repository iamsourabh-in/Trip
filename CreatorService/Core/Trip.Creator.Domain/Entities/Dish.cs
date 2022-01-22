using Trip.Domain.Common.Entities;

namespace Trip.Creator.Domain.Entities
{
    public class Dish : BaseEntity
    {
        public int Name { get; set; }
        public string Ingredients { get; set; }
        public int Preptime { get; set; }
        public int Calories { get; set; }
        public string ImageUrl { get; set; }
        public float Minprice { get; set; }
        public float Maxprice { get; set; }
        public float Fixedprice { get; set; }
        
        public virtual Menu Menu { get; set; }
    }
}
