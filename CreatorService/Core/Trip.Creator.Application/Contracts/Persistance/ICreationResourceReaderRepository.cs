using System.Collections.Generic;
using System.Threading.Tasks;
using Trip.Creator.Domain.Entities;

namespace Trip.Creator.Application.Contracts.Persistance
{
    public interface ICreationResourceReaderRepository : IAsyncReaderRepository<CreationResource>
    {
        Task<List<CreationResource>> GetByCreationIdAsync(string id);

    }
}
