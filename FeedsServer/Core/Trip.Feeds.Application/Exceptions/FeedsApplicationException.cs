using System;
using System.Runtime.Serialization;

namespace Trip.Feeds.Application.Exceptions
{
    [Serializable]
    public class FeedsApplicationException : Exception
    {
        public FeedsApplicationException(string message) : base(message)
        {
        }

        protected FeedsApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
