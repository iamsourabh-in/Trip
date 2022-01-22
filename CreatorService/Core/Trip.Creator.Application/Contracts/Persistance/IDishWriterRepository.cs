using Trip.Creator.Application.Contracts.Persistance.Main;
using Trip.Creator.Domain.Entities;

namespace Trip.Creator.Application.Contracts.Persistance
{
    public interface IDishWriterRepository : IAsyncWriterRepository<Dish>
    {

    }
}
