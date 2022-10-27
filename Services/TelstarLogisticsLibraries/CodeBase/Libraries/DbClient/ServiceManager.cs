using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelstarLogistics.TelstarLogisticsShared.Interfaces;

namespace TelstarLogistics.DbClient
{
    public class ServiceManager : IServiceManager
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDbClient, DbClient>();
        }
    }
}
