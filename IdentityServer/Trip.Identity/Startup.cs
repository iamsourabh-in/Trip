using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("https://localhost:1443/", "http://localhost:1000/", "https://localhost:5443/")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials(); ;
                });
            });

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

            services.AddAuthentication("MyCookieId")
             .AddCookie("MyCookieId", options =>
             {
                 options.AccessDeniedPath = "/account/denied";
                 options.LoginPath = "/account/login";
             });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministratorRole",
                     policy => policy.RequireRole("Admin"));
            });

            //Idenitty Way of doing it Dynamically

            //services.AddSingleton<ICorsPolicyService>((container) =>
            //{
            //	var logger = container.GetRequiredService<ILogger<DefaultCorsPolicyService>>();
            //	return new DefaultCorsPolicyService(logger)
            //	{
            //		AllowedOrigins = { "https://localhost:1443/", "http://localhost:1000/" }
            //	};
            //});



            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //////////////////////////////////////////
            /// Register Messaging Services
            /////////////////////////////////////////
            services.RegisterMessagingService(Configuration);


            services.AddControllersWithViews().AddRazorRuntimeCompilation(); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            };
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());
            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy(cookiePolicyOptions);

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
