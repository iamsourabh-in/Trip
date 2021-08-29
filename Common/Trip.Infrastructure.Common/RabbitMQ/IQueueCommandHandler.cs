namespace AEG.Common.RabbitMQ
{
    public interface IQueueCommandHandler
    {
        public void SetAuthAttributes(string authorizationHeaderToken);
    }
}
