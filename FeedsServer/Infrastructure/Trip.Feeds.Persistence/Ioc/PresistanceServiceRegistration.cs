using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Trip.Feeds.Persistence.Ioc
{
    public static class PresistanceServiceRegistration
    {
        public static IServiceCollection RegisterPersistanceServices(this IServiceCollection services)
        {

            List<Type> implementationToRegister = Assembly.Load("Trip.Feeds.Persistence")
                .GetTypes()
                .Where(x => x.IsClass)
                .Where(x => !string.IsNullOrEmpty(x.Namespace))
                .Where(x => x.Namespace.StartsWith("Trip.Feeds.Persistence")).ToList();

            List<Type> interfaceToRegister = Assembly.Load("Trip.Feeds.Application")
                .GetTypes()
                .Where(x => x.IsInterface)
                .Where(x => !string.IsNullOrEmpty(x.Namespace))
                .Where(x => x.Namespace.StartsWith("Trip.Feeds.Application.Contracts.Persistence")).ToList();


            implementationToRegister.ForEach(implementation =>
            {
                Type[] interfaces = implementation.GetInterfaces();

                if (interfaces.Any())
                {
                    string interfaceName = interfaces.Where(x => x.FullName != null && x.FullName.EndsWith(implementation.Name))?.FirstOrDefault()?.Name;

                    if (!string.IsNullOrWhiteSpace(interfaceName))
                    {

                        Type interfaceType = interfaceToRegister.FirstOrDefault(x => x.Name.Equals(interfaceName));
                        if (interfaceType != null)
                            services.AddScoped(interfaceType, implementation);
                    }
                }
            });

            return services;
        }
    }
}
