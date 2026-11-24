using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DependencyInjection
{
    public static class ServiceRegistrationExtensions
    {
        /// <summary>
        /// Mendaftarkan semua kelas dari assembly tertentu yang berada di namespace tertentu
        /// sebagai implementasi dari interface yang diimplementasikan oleh kelas tersebut.
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="assembly">Assembly yang akan discan</param>
        /// <param name="namespacePrefix">Prefix namespace yang menjadi target (contoh: "System.Application.Services")</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddServicesByConvention(this IServiceCollection services, Assembly assembly, string namespacePrefix)
        {
            var excludedNamespaces = new[]
            {
                $"{namespacePrefix}.Handlers",
                $"{namespacePrefix}.Modules.MessageBroker"
            };

            services.Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses(classes => classes.Where(type =>
                    type.Namespace != null &&
                    type.Namespace.StartsWith(namespacePrefix) &&
                    !excludedNamespaces.Any(ex => type.Namespace.StartsWith(ex))))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }

        public static IServiceCollection AddServicesWorkerByConvention(this IServiceCollection services, Assembly assembly, string namespacePrefix)
        {
            services.Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses(classes => classes.Where(type => type.Namespace != null &&
                                                              (type.Namespace.StartsWith(namespacePrefix + ".Entities") ||
                                                              type.Namespace.StartsWith(namespacePrefix + ".Handlers"))
                                                              ))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
