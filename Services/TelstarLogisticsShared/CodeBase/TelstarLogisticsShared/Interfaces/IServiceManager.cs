using Microsoft.Extensions.DependencyInjection;

namespace TelstarLogistics.TelstarLogisticsShared.Interfaces
{
    public interface IServiceManager
    {
        void ConfigureServices(IServiceCollection services);
    }
}
