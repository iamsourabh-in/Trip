using System.Threading.Tasks;

namespace Trip.Domain.Common.Messaging
{
    public interface IBusPublisher
    {
        Task PublishAsync<TEvent>(string queueName, TEvent @event) where TEvent : IEvent;
    }
}