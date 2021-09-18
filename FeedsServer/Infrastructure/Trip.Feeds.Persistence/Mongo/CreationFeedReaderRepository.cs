using MongoDB.Driver;
using Trip.Feeds.Application.Contracts;
using Trip.Feeds.Domain.Entities;
using Trip.Feeds.Persistence.Mongo.Base;

namespace Trip.Feeds.Persistence.Mongo
{
    public class CreationFeedReaderRepository : BaseReaderRepository<CreationFeed>, ICreationFeedReaderRepository
    {

        public CreationFeedReaderRepository(
            IMongoClient mongoClient,
            IClientSessionHandle clientSessionHandle)
            : base(mongoClient, clientSessionHandle, "creationFeed")
        {
        }
    }
}
