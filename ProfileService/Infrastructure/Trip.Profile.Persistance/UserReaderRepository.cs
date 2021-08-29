using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Profile.Application.Contracts.Persistance;
using Trip.Profile.Domain.Entities;
using Trip.Profile.Persistance.Base;

namespace Trip.Profile.Persistance
{
    public class UserReaderRepository : BaseReaderRepository<User>, IUserReaderRepository
    {
        public UserReaderRepository(ProfileReaderDbContext profileReaderDbContext) : base(profileReaderDbContext)
        {

        }

    }
}
