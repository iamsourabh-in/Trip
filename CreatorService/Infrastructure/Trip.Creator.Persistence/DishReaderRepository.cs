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
    public class DishReaderRepository : BaseReaderRepository<Dish>, IDishReaderRepository
    {

        public DishReaderRepository(CreatorReaderDbContext profileReaderDbContext) : base(profileReaderDbContext)
        {

        }
        public async override Task<Dish> GetAsync(Dish entity)
        {
            return (await _profileReaderDbContext.Dishes.Where(item => item.Id == entity.Id).FirstOrDefaultAsync());
        }

        public async override Task<Dish> GetByIdAsync(string id)
        {
            return (await _profileReaderDbContext.Dishes.Where(item => item.Id == id).FirstOrDefaultAsync());
        }
    }
}
