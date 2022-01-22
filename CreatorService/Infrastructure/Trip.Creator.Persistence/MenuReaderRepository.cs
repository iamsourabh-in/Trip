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
    public class MenuReaderRepository : BaseReaderRepository<Menu>, IMenuReaderRepository
    {

        public MenuReaderRepository(CreatorReaderDbContext profileReaderDbContext) : base(profileReaderDbContext)
        {

        }
        public async override Task<Menu> GetAsync(Menu entity)
        {
            return (await _profileReaderDbContext.Menus.Where(item => item.Id == entity.Id).FirstOrDefaultAsync());
        }

        public async override Task<Menu> GetByIdAsync(string id)
        {
            return (await _profileReaderDbContext.Menus.Where(item => item.Id == id).FirstOrDefaultAsync());
        }
    }
}
