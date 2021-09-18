using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trip.Infrastructure.Common.RabbitMQ;

namespace Trip.Feeds.Messaging.Ioc
{
    public static class MessagingRegistration
    {
        public static IServiceCollection RegisterMessagingService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddRabbitMq(configuration);
            return services;

        }
    }
}
