using ApiCore.Scenarios;
using ApiCore.Scenarios.Interfaces;
using DbClient.Archives;
using DbClient.Archives.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TelstarLogistics.DbClient.Archives;
using TelstarLogistics.DbClient.Archives.Interfaces;
using TelstarLogistics.DbClient.Setup;
using TelstarLogistics.ExternalApiClient;
using TelstarLogistics.ExternalApiClient.Archives;
using TelstarLogistics.ExternalApiClient.Archives.Interfaces;
using TelstarLogistics.TelstarLogisticsShared.Interfaces;

[assembly: FunctionsStartup(typeof(TelstarLogisticsApi.Startup))]

namespace TelstarLogisticsApi
{
    public class Startup : FunctionsStartup
    {
        private static readonly IReadOnlyList<IServiceManager> ProjectDependencies = new IServiceManager[]
        {
            new TelstarLogistics.DbClient.ServiceManager()
        };

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddOptions<DbSettings>()
                .Configure<IConfiguration>((settings, configuration) => { configuration.Bind("DbSettings", settings); });

            //builder.Services.AddLogging();
            ConfigureServices(builder.Services);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // add http client
            services.AddHttpClient<IExternalApiClient, ExternalApiClient>();

            // Configure services from shared projects
            foreach (var projectDependency in ProjectDependencies)
            {
                projectDependency.ConfigureServices(services);
            }

            // add archives
            services.AddSingleton<ITestArchive, TestArchive>();
            services.AddSingleton<IDbTestArchive, DbTestArchive>();
            services.AddSingleton<IContentTypeArchive, ContentTypeArchive>();

            // add scenarios
            services.AddSingleton<ITestScenario, TestScenario>();
            services.AddSingleton<ICityScenario, CityScenario>();
            services.AddSingleton<IContentTypeScenario, ContentTypeScenario>();
            services.AddSingleton<IRouteScenario, RouteScenario>();

            // add error handler
            //services.AddSingleton<IErrorHandler, ErrorHandler>();
        }
    }
}