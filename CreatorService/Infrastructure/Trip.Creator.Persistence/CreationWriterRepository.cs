using Trip.Creator.Application.Contracts.Persistance;
using Trip.Creator.Domain.Entities;
using Trip.Creator.Persistance.Base;
using Trip.Creator.Persistence.Base;

namespace Trip.Creator.Persistence
{
    public class CreationWriterRepository : BaseWriterRepository<Creation>, ICreationWriterRepository
    {
        public CreationWriterRepository(CreatorWriterDbContext profileWriterDbContext) :base(profileWriterDbContext)
        {

        }
       
    }
}
