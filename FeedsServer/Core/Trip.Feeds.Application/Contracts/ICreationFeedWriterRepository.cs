using Trip.Feeds.Application.Contracts.Persistance;
using Trip.Feeds.Domain.Entities;

namespace Trip.Feeds.Application.Contracts
{
    public interface ICreationFeedWriterRepository : IAsyncWriterRepository<CreationFeed>
    {
    }
}
