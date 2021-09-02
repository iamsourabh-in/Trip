using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip.Profile.Domain.Exceptions
{
    public class ProfileDomainException : Exception
    {
        public ProfileDomainException(string message) : base(message)
        {
        }
    }
}
