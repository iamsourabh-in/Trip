using Trip.Creator.Domain.Entities;
using Trip.Creator.Application.Contracts.Persistance.Main;

namespace Trip.Creator.Application.Contracts.Persistance
{
    public interface IRestaurantWriterRepository : IAsyncWriterRepository<Restaurant>
    {

    }
}
