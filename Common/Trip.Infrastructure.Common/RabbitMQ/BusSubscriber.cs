using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Common;
using RawRabbit.Configuration.Exchange;
using System;
using System.Reflection;
using Trip.Domain.Common.Messaging;

namespace Trip.Infrastructure.Common.RabbitMQ
{
    public class BusSubscriber : IBusSubscriber
    {
        private readonly IBusClient _busClient;
        private readonly IServiceProvider _serviceProvider;

        public BusSubscriber(IApplicationBuilder app)
        {
            _serviceProvider = app.ApplicationServices.GetService<IServiceProvider>();
            _busClient = _serviceProvider.GetService<IBusClient>();
        }

        public IBusSubscriber SubscribeEvent<TEvent>(string queueName) where TEvent : IEvent, IRequest
        {
            //Call NLog class logger
            _busClient.SubscribeAsync<TEvent>(async (@event) =>
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var handler = scope.ServiceProvider.GetService<IMediator>();
                    await handler.Send(@event);

                    return new Ack();
                }
                catch (Exception ex)
                {
                    // Need to integrate logger
                    string message = ex.Message;
                    return new Ack();

                    //throw new CustomException(ex.Message);
                }
            }, ctx => ctx.UseSubscribeConfiguration(cfg => cfg
                .Consume(c =>
                    //c.WithRoutingKey(typeof(TEvent).Name)
                    c.WithRoutingKey(queueName)
                )

                .FromDeclaredQueue(q => q
                    //.WithName(GetQueueName<TEvent>())
                    .WithName(queueName)
                    .WithDurability()
                    .WithAutoDelete(false))
                .OnDeclaredExchange(e => e
                  .WithName("Trip")
                  .WithType(ExchangeType.Topic)
                  //.WithArgument("key", typeof(TEvent).Name.ToLower()))
                  .WithArgument("key", queueName))
            )); ;
            return this;
        }

        private static string GetQueueName<T>() => $"{Assembly.GetEntryAssembly()?.GetName()}/{typeof(T).Name}";
    }
}