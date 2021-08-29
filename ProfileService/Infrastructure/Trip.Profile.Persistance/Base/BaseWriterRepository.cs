using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Profile.Application.Contracts.Persistance.Main;

namespace Trip.Profile.Persistance.Base
{
    public class BaseWriterRepository<T> : IAsyncWriterRepository<T> where T : class
    {
        protected readonly ProfileWriterDbContext _profileWriterDbContext;

        public BaseWriterRepository(ProfileWriterDbContext profileWriterDbContext)
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
