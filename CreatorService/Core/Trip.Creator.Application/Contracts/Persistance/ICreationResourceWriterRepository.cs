using Trip.Creator.Domain.Entities;
using Trip.Profile.Application.Contracts.Persistance.Main;

namespace Trip.Creator.Application.Contracts.Persistance
{
    public interface ICreationResourceWriterRepository : IAsyncWriterRepository<CreationResource>
    {


    }
}
