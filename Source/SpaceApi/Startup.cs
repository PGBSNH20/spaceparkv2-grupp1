using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpaceApi.Models;
using System.Text;
using Microsoft.AspNetCore.Http;
using SpaceApi.Data;

namespace SpaceApi
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
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpaceApi", Version = "v1", Description = "The best space park in space"}); });
            services.AddDbContext<SpaceContext>(o => o.UseSqlServer(Configuration.GetConnectionString("SpaceDatabase")));
            services.AddScoped<IParkingDataStore, ParkingDataStore>();
            services.AddScoped<IPaymentsDataStore, PaymentsDataStore>();
            services.AddScoped<ISpacePortDataStore, SpacePortDataStore>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SpaceContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpaceApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.Use(async (httpContext, next) =>
            {
                var key = Configuration["ApiKey"]; // Get very secret api key from appsettings
                
                if (httpContext.Request.Headers["apikey"] == key) // Check if request headers contains the key value
                {
                    await next();
                }
                else // Return 401 message if not
                {
                    httpContext.Response.StatusCode = 401;
                    var jsonString = "{\"Message\": \"API key was not provided\",\"Response\": " + httpContext.Response.StatusCode + "}";
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsync(jsonString, Encoding.UTF8);
                }
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            if(context.Database.GetPendingMigrations() != null || context.Database.GetPendingMigrations().Any()) // We use this to automatically update the database schema when starting our docker containers.
                context.Database.Migrate(); 

        }
    }
}