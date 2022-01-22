using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Creator.Domain.Entities;

namespace Trip.Creator.Application.Contracts.Persistance
{
    public interface IRestaurantReaderRepository : IAsyncReaderRepository<Restaurant>
    {

    }
}
