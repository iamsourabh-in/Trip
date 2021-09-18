using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Feeds.Application.Contracts.Persistance;
using Trip.Feeds.Domain.Entities;

namespace Trip.Feeds.Application.Contracts
{
    public interface ICreationFeedReaderRepository : IAsyncReaderRepository<CreationFeed>
    {
    }
}
