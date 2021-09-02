using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trip.Profile.Api.ExceptionHandling
{
    public class ProfileApiException : Exception
    {

        public ProfileApiException(string message):base(message)
        {

        }
    }
}
