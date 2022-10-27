using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TelstarLogistics.TelstarLogisticsShared.Extensions
{
    public static class ServiceMangerExtension
    {
        /// <summary>
        /// Adds all services by the default naming convention to this <see cref="IServiceCollection"/>.
        /// Services are added by their interface only.
        /// </summary>
        public static void AddDefaultServices(this IServiceCollection services, Assembly callingAssembly)
        {
            var serviceClasses = callingAssembly.DefinedTypes
                .Where(t => !t.IsAbstract & !t.IsInterface);

            var serviceInterfaces = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.FullName.StartsWith(nameof(TelstarLogistics), StringComparison.Ordinal))
                .SelectMany(a => a.ExportedTypes)
                .Where(t => t.IsInterface)
                .ToLookup(i => i.Name, StringComparer.Ordinal);

            foreach (var serviceClass in serviceClasses)
            {
                var conventionalInterfaceName = $"I{serviceClass.Name}";
                var serviceInterface = serviceInterfaces[conventionalInterfaceName]
                    .FirstOrDefault(si => si.IsAssignableFrom(serviceClass));
                if (serviceInterface != null)
                {
                    services.AddTransient(serviceInterface, serviceClass);
                }
            }
        }
    }
}
