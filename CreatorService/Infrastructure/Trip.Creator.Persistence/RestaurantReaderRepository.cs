using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Creator.Application.Contracts.Persistance;
using Trip.Creator.Domain.Entities;
using Trip.Creator.Persistance.Base;
using Trip.Creator.Persistence.Base;

namespace Trip.Creator.Persistence
{
    public class RestaurantReaderRepository : BaseReaderRepository<Restaurant>, IRestaurantReaderRepository
    {

        public RestaurantReaderRepository(CreatorReaderDbContext profileReaderDbContext) : base(profileReaderDbContext)
        {

        }
        public async override Task<Restaurant> GetAsync(Restaurant entity)
        {
            return (await _profileReaderDbContext.Restaurants.Where(item => item.Id == entity.Id).FirstOrDefaultAsync());
        }

        public async override Task<Restaurant> GetByIdAsync(string id)
        {
            return (await _profileReaderDbContext.Restaurants.Where(item => item.Id == id).FirstOrDefaultAsync());
        }
    }
}
