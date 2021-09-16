using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trip.Creator.Application.Contracts.Messaging;
using Trip.Infrastructure.Common.RabbitMQ;

namespace Trip.Creator.Messaging.Ioc
{
    public static class MessagingRegistration
    {
        public static IServiceCollection RegisterMessagingService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddRabbitMq(configuration);
            services.AddScoped<IQueuePubliser, QueuePubliser>();
            return services;

        }
    }
}
