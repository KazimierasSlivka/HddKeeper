using Microsoft.Extensions.DependencyInjection;
using HddKeeper.BusinessLogic;
using HddKeeper.Contracts.Interfaces;
using Microsoft.Extensions.Configuration;

namespace HddKeeper.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<App>().Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<App>();

            services.AddScoped<IDriveController, DriveController>();

            return services;
        }
    }
}
