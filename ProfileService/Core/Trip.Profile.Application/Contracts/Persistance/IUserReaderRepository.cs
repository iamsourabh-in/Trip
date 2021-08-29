using System.Threading.Tasks;
using Trip.Profile.Domain.Entities;

namespace Trip.Profile.Application.Contracts.Persistance
{
    public interface IUserReaderRepository : IAsyncReaderRepository<User>
    {
     
       
    }
}
