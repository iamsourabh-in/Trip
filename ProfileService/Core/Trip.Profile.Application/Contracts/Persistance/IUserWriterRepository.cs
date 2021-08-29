using Trip.Profile.Application.Contracts.Persistance.Main;
using Trip.Profile.Domain.Entities;

namespace Trip.Profile.Application.Contracts.Persistance
{
    public interface IUserWriterRepository : IAsyncWriterRepository<User>
    {
  

    }
}
