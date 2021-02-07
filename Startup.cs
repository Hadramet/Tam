using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Tam.webapp.Controllers;
using Tam.webapp.Db;
using Tam.webapp.Repositories;
using Tam.webapp.Repositories.PlayLists;
using Tam.webapp.Repositories.Track;
using Tam.webapp.Repositories.TrackPlayList;
using Tam.webapp.Repositories.User;
using Tam.webapp.Repositories.UserPlayList;
using Tam.webapp.Services;
using Tam.webapp.Services.PlayList;
using Tam.webapp.Services.Track;

namespace Tam.webapp
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
            services.AddControllersWithViews();

            services.AddScoped<IPlayListsRepository, PlayListsRepository>();
            services.AddScoped<ITrackPlayListRepository, TrackPlayListRepository>();
            services.AddScoped<ITrackRepository, TrackRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserPlayListRepository, UserPlayListsRepository>();
            
            services.AddTransient<IPlayListService, PlayListService>();
            services.AddTransient<ITrackService, TrackService>();

            // Register Tam Database context
            services.AddDbContext<TamDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Tam")));
            
            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession();
            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            app.UseAuthentication();
            if (Configuration["EnableDeveloperExceptions"] == "True")
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
