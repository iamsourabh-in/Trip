using Trip.Creator.Application.Contracts.Persistance;
using Trip.Creator.Domain.Entities;
using Trip.Creator.Persistance.Base;
using Trip.Creator.Persistence.Base;

namespace Trip.Creator.Persistence
{
    public class CreationResourceWriterRepository : BaseWriterRepository<CreationResource>, ICreationResourceWriterRepository
    {
        public CreationResourceWriterRepository(CreatorWriterDbContext creatorWriterDbContext) : base(creatorWriterDbContext)
        {

        }

    }
}
