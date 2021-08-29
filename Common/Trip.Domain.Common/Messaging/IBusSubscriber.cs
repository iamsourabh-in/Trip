using MediatR;

namespace Trip.Domain.Common.Messaging
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeEvent<TEvent>(string queueName) where TEvent : IEvent, IRequest;
    }
}