using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TelstarLogistics.ExternalApiClient;
using TelstarLogistics.TelstarLogisticsShared.Interfaces;

[assembly: FunctionsStartup(typeof(TelstarLogisticsApi.Startup))]
namespace TelstarLogisticsApi
{
    public class Startup : FunctionsStartup
    {
        private static readonly IReadOnlyList<IServiceManager> ProjectDependencies = new IServiceManager[]
        {
            //new DbClient.ServiceRegistration(),
        };

        public override void Configure(IFunctionsHostBuilder builder)
        {
            //builder.Services
            //    .AddOptions<Options>()
            //    .Configure<IConfiguration>((settings, configuration) => { configuration.Bind("Options", settings); });

            //builder.Services.AddLogging();
            ConfigureServices(builder.Services);
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // add http client
            services.AddHttpClient<IExternalApiClient, ExternalApiClient>();

            // Add fdcp repositories
            //services.AddSingleton<ITestRepository, TestRepository>();

            // Configure services from shared projects
            foreach (var projectDependency in ProjectDependencies)
            {
                projectDependency.ConfigureServices(services);
            }

            // add archives
            //services.AddSingleton<IArchive, Archive>();

            // add scenarios
            //services.AddSingleton<IScenarions, Scenarions>();



            // add error handler
            //services.AddSingleton<IErrorHandler, ErrorHandler>();

        }
    }
}
