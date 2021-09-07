using System.Threading.Tasks;
using Trip.Creator.Application.Contracts.Persistance.Main;
using Trip.Creator.Persistence.Base;

namespace Trip.Creator.Persistance.Base
{
    public class BaseWriterRepository<T> : IAsyncWriterRepository<T> where T : class
    {
        protected readonly CreatorWriterDbContext _profileWriterDbContext;

        public BaseWriterRepository(CreatorWriterDbContext profileWriterDbContext)
        {
            _profileWriterDbContext = profileWriterDbContext;
        }

        public async Task DeleteAsync(T entity)
        {
            _profileWriterDbContext.Set<T>().Remove(entity);
            await _profileWriterDbContext.SaveChangesAsync();
        }
         
        public async Task<T> SaveAsync(T entity)
        {
            _profileWriterDbContext.Set<T>().Add(entity);
            await _profileWriterDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _profileWriterDbContext.Set<T>().Update(entity);
            await _profileWriterDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
