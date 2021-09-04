using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Trip.Identity.Messaging.Ioc;
using Trip.Identity.Persistence.Data;

namespace Trip.Identity
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"), opt => opt.MigrationsAssembly(migrationAssembly)));

            ////////////////////////////////////////////////////
            /// Make the Idenitty Server use Identity User
            ///////////////////////////////////////////////////
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            //////////////////////////////////////////
            /// Register Identity Server
            //////////////////////////////////////////
            services.AddIdentityServer()
                  //.AddInMemoryClients(Config.Clients)
                  //.AddInMemoryIdentityResources(Config.IdentityResources)
                  //.AddInMemoryApiResources(Config.ApiResources)
                  //.AddInMemoryApiScopes(Config.ApiScopes)
                  .AddAspNetIdentity<ApplicationUser>()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseSqlite(connectionString, opt => opt.MigrationsAssembly(migrationAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseSqlite(connectionString, opt => opt.MigrationsAssembly(migrationAssembly));
                })
                .AddDeveloperSigningCredential();

            //////////////////////////////////////////
            /// Register Messaging Services
            /////////////////////////////////////////
            services.RegisterMessagingService(Configuration);


            services.AddControllersWithViews().AddRazorRuntimeCompilation(); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                          name: "Admin",
                          pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
