using RawRabbit;
using RawRabbit.Configuration.Exchange;
using System.Threading.Tasks;
using Trip.Domain.Common.Messaging;

namespace Trip.Infrastructure.Common.RabbitMQ
{
    public class BusPublisher : IBusPublisher
    {
        private readonly IBusClient _busClient;

        public BusPublisher(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public async Task PublishAsync<TEvent>(string queueName, TEvent @event) where TEvent : IEvent
        {
            await _busClient.PublishAsync(@event, ctx => ctx
                .UsePublishConfiguration(cfg => cfg
                    .OnDeclaredExchange(e => e
                        .WithName("Trip")
                        .WithType(ExchangeType.Topic))
                    .WithRoutingKey(queueName)));
            //.WithRoutingKey(typeof(TEvent).Name)));
        }
    }
}