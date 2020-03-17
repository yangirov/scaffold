using System.Reflection;

using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Api.Infrastructure;
using BusinessLogic.Services;
using Contracts.Models;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(ILogger), services.BuildServiceProvider().GetService<ILogger<CustomLogger>>());
            services.AddAutoMapper(Assembly.GetAssembly(typeof(Services.Mappers.DependencyInjectionProfile)));
            
            services.AddControllers();
            services.AddSingleton<IConfiguration>(Configuration);

            var connectionString = Configuration.GetValue<string>("ConnectionStrings:Database");
            
            //services.AddTransient<IDtoService<BookDto, int>>(
            //    x => new BookService(connectionString, x.GetRequiredService<ILogger>(), x.GetRequiredService<IMapper>()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
