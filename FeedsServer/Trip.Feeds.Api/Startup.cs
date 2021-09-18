using EasyException.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System;
using Trip.Domain.Common;
using Trip.Domain.Common.IntegrationEventModels;
using Trip.Feeds.Api.ExceptionHandling;
using Trip.Feeds.Application.Ioc;
using Trip.Feeds.Messaging.Ioc;
using Trip.Feeds.Persistence.Ioc;
using Trip.Infrastructure.Common.RabbitMQ;

namespace Trip.Feeds.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.ApiName = "tripfeed";
                    options.Authority = "https://localhost:5443";
                    options.RequireHttpsMetadata = false;
                });

            //////////////////////////////////////////
            /// Register Persistance Services
            /////////////////////////////////////////
            services.RegisterPersistanceServices();

            //////////////////////////////////////////
            /// Register Application Services
            /////////////////////////////////////////
            services.RegisterApplicationServices();

            //////////////////////////////////////////
            /// Register Messaging Services
            /////////////////////////////////////////
            services.RegisterMessagingService(Configuration);

            services.AddSingleton<IErrorHandlingService, ErrorHandlingService>();

            services.AddSingleton<IMongoClient>(c =>
            {
                var login = "";
                var password = Uri.EscapeDataString("");
                var server = "";

                return new MongoClient(string.Format("mongodb://localhost:27017"));
            });

            services.AddScoped(c =>
                c.GetService<IMongoClient>().StartSession());


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Trip.Feeds.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trip.Feeds.Api v1"));
            }

            SubscribeEvents(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        private static void SubscribeEvents(IApplicationBuilder app)
        {
            app.UseRabbitMq().SubscribeEvent<CreateCreationFeedFromCreationEvent>(IntegrationQueues.CreateCreationFeedFromCreationEventQueue);
        }
    }
}
