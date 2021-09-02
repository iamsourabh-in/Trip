using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trip.Profile.Api.ExceptionHandling
{
    public class TripProfileApiException : Exception
    {

        public TripProfileApiException(string message):base(message)
        {

        }
    }
}
