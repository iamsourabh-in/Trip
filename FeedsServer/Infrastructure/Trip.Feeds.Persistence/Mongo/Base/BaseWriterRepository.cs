using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trip.Feeds.Application.Contracts.Persistance;
using Trip.Feeds.Domain.Base;

namespace Trip.Feeds.Persistence.Mongo.Base
{
    public class BaseWriterRepository<T> : IAsyncWriterRepository<T> where T : BaseEntity
    {
        private const string DATABASE = "feeder";
        private readonly IMongoClient _mongoClient;
        private readonly IClientSessionHandle _clientSessionHandle;
        private readonly string _collection;
        protected virtual IMongoCollection<T> Collection =>
        _mongoClient.GetDatabase(DATABASE).GetCollection<T>(_collection);

        public BaseWriterRepository(IMongoClient mongoClient, IClientSessionHandle clientSessionHandle, string collection)
        {
            (_mongoClient, _clientSessionHandle, _collection) = (mongoClient, clientSessionHandle, collection);

            if (!_mongoClient.GetDatabase(DATABASE).ListCollectionNames().ToList().Contains(collection))
                _mongoClient.GetDatabase(DATABASE).CreateCollection(collection);
        }

        public async Task DeleteAsync(T entity)
        {
            await Collection.DeleteOneAsync(_clientSessionHandle, f => f.Id == entity.Id);
        }

        public async Task<T> SaveAsync(T entity)
        {
            await Collection.InsertOneAsync(_clientSessionHandle, entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            Expression<Func<T, string>> func = f => f.Id;
            var value = (string)entity.GetType().GetProperty(func.Body.ToString().Split(".")[1]).GetValue(entity, null);
            var filter = Builders<T>.Filter.Eq(func, value);

            if (entity != null)
                await Collection.ReplaceOneAsync(_clientSessionHandle, filter, entity);

            return entity;
        }
    }
}
