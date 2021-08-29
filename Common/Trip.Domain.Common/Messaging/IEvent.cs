namespace Trip.Domain.Common.Messaging
{
    /// <summary>
    ///Use for Any Queue
    /// </summary>
    public interface IEvent
    {

    }

    /// <summary>
    /// Use Where Authorzation in the queue is to be maintained.
    /// </summary>
    public interface IAuthEvent : IEvent
    {
        public string Authorization { get; set; }
        public int RetryCount { get; set; }
    }
}