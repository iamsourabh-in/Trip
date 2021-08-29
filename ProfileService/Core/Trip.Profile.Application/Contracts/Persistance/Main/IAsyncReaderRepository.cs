using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Profile.Domain.Base;

namespace Trip.Profile.Application.Contracts.Persistance
{
    public interface IAsyncReaderRepository<T> where T: class
    {
        Task<T> GetAsync(T entity);

        Task<T> GetByIdAsync(int id);
    }
}
