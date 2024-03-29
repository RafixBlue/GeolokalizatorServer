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
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using GeolokalizatorServer.Models.Validators;
using GeolokalizatorServer.Models;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GeolokalizatorServer.Middleware;

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
            var authenticationSettings = new AuthenticationSettings();

            Configuration.GetSection("Authentication").Bind(authenticationSettings);
            services.AddSingleton(authenticationSettings);

            services
                .AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            })
                .AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });
            
            //dodawanie kontrolerów
            services.AddControllers();

            //validation
            services.AddFluentValidationAutoValidation();

            //automaper
            services.AddAutoMapper(this.GetType().Assembly);

            services.AddDbContext<GeolokalizatorDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GeolokalizatorDbConnection")));
            services.AddScoped<GeolokalizatorSeeder>();

            //serwisy
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICollectionTimeService, CollectionTimeService>();
            services.AddScoped<ICollectedDataService, CollectedDataService>();
            services.AddScoped<ISynchronizationService, SynchronizationService>();
            services.AddScoped<IUserContextService, UserContextService>();

            services.AddScoped<ErrorHandlingMiddleware>();
            
            services.AddHttpContextAccessor();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GeolokalizatorSeeder geoSeeder)
        {
            geoSeeder.Seed();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseAuthentication();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
