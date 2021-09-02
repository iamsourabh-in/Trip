using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip.Profile.Application.Exceptions
{
    public class ProfileApplicationException : Exception
    {
        public ProfileApplicationException(string message) : base(message)
        {
        }
    }
}
