using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Trip.Api.Common.HealthChecks;
using Trip.Domain.Common.Messaging.Identity;
using Trip.Infrastructure.Common.RabbitMQ;
using Trip.Profile.Application.Ioc;
using Trip.Profile.Messaging.Ioc;
using Trip.Profile.Persistance.Base;
using Trip.Profile.Persistance.Ioc;

namespace Trip.Profile.Api
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
            //////////////////////////////////////////
            /// Token Validation using IdentityServer4 Jwks
            /////////////////////////////////////////
            services.AddAuthentication("Bearer")
            .AddIdentityServerAuthentication("Bearer", options =>
            {
                options.ApiName = "tripfeed";
                options.Authority = "https://localhost:5443";
                options.RequireHttpsMetadata = false;
            });

            //////////////////////////////////////////
            /// Register Db Context
            /////////////////////////////////////////
            var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<ProfileReaderDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("ProfileReader"), opt => opt.MigrationsAssembly(migrationAssembly)));
            services.AddDbContext<ProfileWriterDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("ProfileWriter"), opt => opt.MigrationsAssembly(migrationAssembly)));

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

            services.AddControllers();

            //////////////////////////////////////////
            /// Register Open APi Spec Services
            /////////////////////////////////////////
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Trip.Profile.Api", Version = "v1" });
            });

            #region snippet_ConfigureServices
            services.AddHealthChecks().AddMemoryHealthCheck("memory");
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trip.Profile.Api v1"));
            }

            SubscribeEvents(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    // This custom writer formats the detailed status as JSON.
                    ResponseWriter = WriteResponse
                });
            });
        }

        private static void SubscribeEvents(IApplicationBuilder app)
        {
            app.UseRabbitMq().SubscribeEvent<NewUserCreatedInIdentityEvent>("NewUserCreatedInIdentity");
        }

        #region snippet_WriteResponse
        private static Task WriteResponse(HttpContext httpContext,
            HealthReport result)
        {
            httpContext.Response.ContentType = "application/json; charset=utf-8";

            var json = new JObject(
                new JProperty("status", result.Status.ToString()),
                new JProperty("results", new JObject(result.Entries.Select(pair =>
                    new JProperty(pair.Key, new JObject(
                        new JProperty("status", pair.Value.Status.ToString()),
                        new JProperty("description", pair.Value.Description),
                        new JProperty("data", new JObject(pair.Value.Data.Select(
                            p => new JProperty(p.Key, p.Value))))))))));
            return httpContext.Response.WriteAsync(
                json.ToString(Formatting.Indented));
        }
        #endregion
    }
}
