using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsynchInnLab.Data;
using AsynchInnLab.Models;
using AsynchInnLab.Models.Interfaces;
using AsynchInnLab.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace AsynchInnLab
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //this is where all of our dependencies are going to live.
            //Enable the use of using controllers within the MVC convention
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //Register with the app that the database exists and what options to use for it.
            services.AddDbContext<AsynchInDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AsynchInDbContext>()
                .AddDefaultTokenProviders();

            //register my Dependency Injection Services
            services.AddTransient<IHotel, HotelRepository>();
            services.AddTransient<IAmenity, AmenityRepository>();
            services.AddTransient<IRoom, RoomRepository>();
            services.AddTransient<IHotelRoom, HotelRoomRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //Set our default routing for our request within the API app
                //By default, our convention is {site}/[controller]/[action]/[id]
                //id is not required, allowing it to be nullable
                endpoints.MapControllerRoute("Default route", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
