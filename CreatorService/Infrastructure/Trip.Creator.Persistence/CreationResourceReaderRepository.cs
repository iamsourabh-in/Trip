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
    public class CreationResourceReaderRepository : BaseReaderRepository<CreationResource>, ICreationResourceReaderRepository
    {
        public CreationResourceReaderRepository(CreatorReaderDbContext profileReaderDbContext) : base(profileReaderDbContext)
        {

        }

        public async override Task<CreationResource> GetAsync(CreationResource entity)
        {
            return (await _profileReaderDbContext.CreationResource.Where(item => item.Id == entity.Id).FirstOrDefaultAsync());
        }

        public async Task<List<CreationResource>> GetByCreationIdAsync(string id)
        {
            return await _profileReaderDbContext.CreationResource.Where(item => item.Creation.Id == id).ToListAsync();
        }

        public async override Task<CreationResource> GetByIdAsync(string id)
        {
            return (await _profileReaderDbContext.CreationResource.Where(item => item.Id == id).FirstOrDefaultAsync());
        }


    }
}
