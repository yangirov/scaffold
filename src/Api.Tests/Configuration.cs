using System.Reflection;

using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Api.Tests
{
    public static class Configuration
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            return config;
        }

        public static ILogger InitLogger()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
                    .AddConsole()
                    .AddEventLog();
            });
            ILogger logger = loggerFactory.CreateLogger<Program>();

            return logger;
        }

        public static IMapper InitMapper()
        {
            var assembly = Assembly.GetAssembly(typeof(Services.Mappers.DependencyInjectionProfile));
            var mapper = new MapperConfiguration(cfg => cfg.AddMaps(assembly)).CreateMapper();
            return mapper;
        }
    }
}
