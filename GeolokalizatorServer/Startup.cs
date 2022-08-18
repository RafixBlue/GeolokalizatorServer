using GeolokalizatorSerwer.Entities;
using GeolokalizatorSerwer.Services.Interfaces;
using GeolokalizatorSerwer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeolokalizatorServer.Services;
using GeolokalizatorServer.Services.Interfaces;

namespace GeolokalizatorServer
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

            services.AddControllers();

            services.AddAutoMapper(this.GetType().Assembly);//automaper

            services.AddDbContext<GeolokalizatorDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GeolokalizatorDbConnection")));
            services.AddScoped<GeolokalizatorSeeder>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICollectionTimeService, CollectionTimeService>();
            services.AddScoped<ICollectedDataService, CollectedDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GeolokalizatorSeeder geoSeeder)
        {
            geoSeeder.Seed();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
