using System;

namespace Trip.Creator.Api.ExceptionHandling
{
    public class CreatorApiException : Exception
    {
        public CreatorApiException(string message):base(message)
        {

        }
    }
}
