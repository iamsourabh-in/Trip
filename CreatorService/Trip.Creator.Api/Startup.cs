using EasyException.Abstractions;
using EasyException.Middleware;
using EasyException.Models;
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
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Trip.Api.Common.HealthChecks;
using Trip.Creator.Api.ExceptionHandling;
using Trip.Creator.Application.Ioc;
using Trip.Creator.Persistence.Base;
using Trip.Creator.Persistence.Ioc;

namespace Trip.Creator.Api
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
                options.ApiName = "tripcreator";
                options.Authority = "https://localhost:5443";
                options.RequireHttpsMetadata = false;
            });

            //////////////////////////////////////////
            /// Register Db Context
            /////////////////////////////////////////
            var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<CreatorReaderDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("CreatorReader"), opt => opt.MigrationsAssembly(migrationAssembly)));
            services.AddDbContext<CreatorWriterDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("CreatorWriter"), opt => opt.MigrationsAssembly(migrationAssembly)));

            //////////////////////////////////////////
            /// Register Persistance Services
            /////////////////////////////////////////
            services.RegisterPersistanceServices();

            ////////////////////////////////////////////
            ///// Register Application Services
            ///////////////////////////////////////////
            services.RegisterApplicationServices();

            ////////////////////////////////////////////
            ///// Register Messaging Services
            ///////////////////////////////////////////
            //services.RegisterMessagingService(Configuration);

            services.AddSingleton<IErrorHandlingService, ErrorHandlingService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Trip.Creator.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trip.Creator.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
