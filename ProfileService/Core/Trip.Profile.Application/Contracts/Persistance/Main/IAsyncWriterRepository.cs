using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Profile.Domain.Base;

namespace Trip.Profile.Application.Contracts.Persistance.Main
{
    public interface IAsyncWriterRepository<T> where T : class
    {
        Task<T> SaveAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
