using Microsoft.Extensions.DependencyInjection;
using TelstarLogistics.TelstarLogisticsShared.Extensions;
using TelstarLogistics.TelstarLogisticsShared.Interfaces;

namespace TelstarLogistics.TelstarLogisticsShared
{
    public class ServiceManager : IServiceManager
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDefaultServices(GetType().Assembly);
        }
    }
}