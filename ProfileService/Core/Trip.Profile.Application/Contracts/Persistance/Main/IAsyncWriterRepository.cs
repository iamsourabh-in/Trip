using System.Threading.Tasks;

namespace Trip.Profile.Application.Contracts.Persistance.Main
{
    public interface IAsyncWriterRepository<T> where T : class
    {
        Task<T> SaveAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
