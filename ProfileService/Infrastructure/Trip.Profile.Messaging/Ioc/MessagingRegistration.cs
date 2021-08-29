using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Infrastructure.Common.RabbitMQ;

namespace Trip.Profile.Messaging.Ioc
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
