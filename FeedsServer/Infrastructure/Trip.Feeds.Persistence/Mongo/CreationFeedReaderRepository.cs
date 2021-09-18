using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
