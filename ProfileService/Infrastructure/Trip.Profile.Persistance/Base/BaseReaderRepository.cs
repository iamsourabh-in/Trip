using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Profile.Application.Contracts.Persistance;

namespace Trip.Profile.Persistance.Base
{
    public abstract class BaseReaderRepository<T> : IAsyncReaderRepository<T> where T : class
    {

        protected readonly ProfileReaderDbContext _profileReaderDbContext;

        public BaseReaderRepository(ProfileReaderDbContext profileReaderDbContext)
        {
            _profileReaderDbContext = profileReaderDbContext;
        }

        public abstract Task<T> GetAsync(T entity);


        public abstract Task<T> GetByIdAsync(int id);

    }
}
