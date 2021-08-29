using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Profile.Application.Contracts.Persistance;

namespace Trip.Profile.Persistance.Base
{
    public class BaseReaderRepository<T> : IAsyncReaderRepository<T> where T : class
    {

        private readonly ProfileReaderDbContext _profileReaderDbContext;

        public BaseReaderRepository(ProfileReaderDbContext profileReaderDbContext)
        {
            _profileReaderDbContext = profileReaderDbContext;
        }

        public async Task<T> GetAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
