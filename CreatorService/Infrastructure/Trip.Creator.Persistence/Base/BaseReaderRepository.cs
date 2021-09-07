using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Creator.Application.Contracts.Persistance;
using Trip.Creator.Persistence.Base;

namespace Trip.Creator.Persistance.Base
{
    public abstract class BaseReaderRepository<T> : IAsyncReaderRepository<T> where T : class
    {

        protected readonly CreatorReaderDbContext _profileReaderDbContext;

        public BaseReaderRepository(CreatorReaderDbContext profileReaderDbContext)
        {
            _profileReaderDbContext = profileReaderDbContext;
        }

        public abstract Task<T> GetAsync(T entity);


        public abstract Task<T> GetByIdAsync(string id);

    }
}
