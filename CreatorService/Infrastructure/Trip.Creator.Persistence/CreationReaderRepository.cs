using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Trip.Creator.Application.Contracts.Persistance;
using Trip.Creator.Domain.Entities;
using Trip.Creator.Persistance.Base;
using Trip.Creator.Persistence.Base;

namespace Trip.Creator.Persistence
{
    public class CreationReaderRepository : BaseReaderRepository<Creation>, ICreationReaderRepository
    {
        public CreationReaderRepository(CreatorReaderDbContext profileReaderDbContext) : base(profileReaderDbContext)
        {

        }

        public async override Task<Creation> GetAsync(Creation entity)
        {
            return (await _profileReaderDbContext.Creation.Where(item => item.Id == entity.Id).FirstOrDefaultAsync());
        }

        public async override Task<Creation> GetByIdAsync(string id)
        {
            return (await _profileReaderDbContext.Creation.Where(item => item.Id == id).FirstOrDefaultAsync());
        }
    }
}
