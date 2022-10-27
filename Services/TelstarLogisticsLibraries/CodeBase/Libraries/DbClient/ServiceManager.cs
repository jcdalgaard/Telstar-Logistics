using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelstarLogistics.DbClient.Setup;
using TelstarLogistics.TelstarLogisticsShared.Interfaces;

namespace TelstarLogistics.DbClient
{
    public class ServiceManager : IServiceManager
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(ServiceLifetime.Transient);
        }
    }
}
