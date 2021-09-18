using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;
using Trip.Feeds.Application.Contracts.Persistance;
using Trip.Feeds.Domain.Base;

namespace Trip.Feeds.Persistence.Mongo.Base
{
    public class BaseReaderRepository<T> : IAsyncReaderRepository<T> where T : BaseEntity
    {
        private const string DATABASE = "feeder";
        private readonly IMongoClient _mongoClient;
        private readonly IClientSessionHandle _clientSessionHandle;
        private readonly string _collection;

        protected virtual IMongoCollection<T> Collection =>
       _mongoClient.GetDatabase(DATABASE).GetCollection<T>(_collection);

        public BaseReaderRepository(IMongoClient mongoClient, IClientSessionHandle clientSessionHandle, string collection)
        {
            (_mongoClient, _clientSessionHandle, _collection) = (mongoClient, clientSessionHandle, collection);

            if (!_mongoClient.GetDatabase(DATABASE).ListCollectionNames().ToList().Contains(collection))
                _mongoClient.GetDatabase(DATABASE).CreateCollection(collection);
        }


        public async Task<T> GetAsync(T entity)
        {
            return (await Collection.FindAsync(_clientSessionHandle, f => f.Id == entity.Id)).FirstOrDefault();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return (await Collection.FindAsync(_clientSessionHandle, f => f.Id == id)).FirstOrDefault();
        }
    }
}
