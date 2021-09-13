using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Trip.Application.Common.Behaviour;

namespace Trip.Creator.Application.Ioc
{
    public static class ApplicationServiceRegistration
	{
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            //////////////////////////////////////////
            /// Register Application Services
            /////////////////////////////////////////

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehaviour<,>));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            return services;

        }
    }
}
