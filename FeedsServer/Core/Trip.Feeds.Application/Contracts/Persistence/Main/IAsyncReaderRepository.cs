using System.Threading.Tasks;

namespace Trip.Feeds.Application.Contracts.Persistance
{
    public interface IAsyncReaderRepository<T> where T: class
    {
        Task<T> GetAsync(T entity);

        Task<T> GetByIdAsync(string id);
    }
}
