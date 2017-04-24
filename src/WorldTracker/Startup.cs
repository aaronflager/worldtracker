using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using WorldTracker.Repositories;
using WorldTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WorldTracker
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            //.AddJsonFile("appsettings.json").Build();
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true).Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                                Configuration["Data:WorldTracker:ConnectionString"]));

            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(
                    Configuration["Data:WorldTrackerIdentity:ConnectionString"]));

            services.AddIdentity<WorldUser, IdentityRole>(opts =>
            { opts.Cookies.ApplicationCookie.LoginPath = "/Auth/Login"; })
                 .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddMvc();
            services.AddTransient<ICharacterRepository, CharacterRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentity();
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            SeedData.EnsurePopulated(app);
        }
    }
}
