using DickinsonBros.DateTime.Abstractions;
using DickinsonBros.DateTime.Runner.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DickinsonBros.DateTime.Runner
{
    class Program
    {
        IConfiguration _configuration;
        async static Task Main(string[] args)
        {
            await new Program().DoMain();
        }
        async Task DoMain()
        {
            try
            {
                using (var applicationLifetime = new ApplicationLifetime())
                {
                    var services = InitializeDependencyInjection();
                    ConfigureServices(services, applicationLifetime);

                    using (var provider = services.BuildServiceProvider())
                    {
                        var dateTimeService = provider.GetRequiredService<IDateTimeService>();

                        Console.WriteLine
                        (
$@"DateTimeUTC 1: 
{dateTimeService.GetDateTimeUTC()}

DateTimeUTC 2: 
{dateTimeService.GetDateTimeUTC().ToShortDateString()}

DateTimeUTC 3:
{dateTimeService.GetDateTimeUTC().ToLongDateString()}

"
                        );
                    }
                    applicationLifetime.StopApplication();
                    await Task.CompletedTask.ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("End...");
                Console.ReadKey();
            }
        }

        private void ConfigureServices(IServiceCollection services, ApplicationLifetime applicationLifetime)
        {
            services.AddOptions();
            IServiceCollection serviceCollection = services.AddLogging(config =>
            {
                config.AddConfiguration(_configuration.GetSection("Logging"));

                if (Environment.GetEnvironmentVariable("BUILD_CONFIGURATION") == "DEBUG")
                {
                    config.AddConsole();
                }
            });
            services.AddSingleton<IApplicationLifetime>(applicationLifetime);
            services.AddSingleton<IDateTimeService, DateTimeService>();
        }

        IServiceCollection InitializeDependencyInjection()
        {
            var aspnetCoreEnvironment = Environment.GetEnvironmentVariable("BUILD_CONFIGURATION");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{aspnetCoreEnvironment}.json", true);
            _configuration = builder.Build();
            var services = new ServiceCollection();
            services.AddSingleton(_configuration);
            return services;
        }
    }
}
