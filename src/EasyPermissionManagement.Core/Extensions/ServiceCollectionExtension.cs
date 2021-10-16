using EasyPermissionManagement.Core.Abstractions;
using EasyPermissionManagement.Core.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Extensions
{
    /// <summary>
    /// Service Collection Extension
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Configure Easy Permission
        /// </summary>
        /// <param name="services">
        /// Specifies the contract for a collection of service descriptors.
        /// </param>
        /// <returns>
        /// IServiceCollection
        /// </returns>
        public static IServiceCollection AddEasyPermission(this IServiceCollection services)
        {
            services.AddTransient<IPermissionDefinationContext, PermissionDefinationContext>();
            services.AddTransient<IPermissionProvider, PermissionProviderManager>();
            services.AddTransient<IPermissionChecker, PermissionCheckerManager>();
            return services;
        }
    }
}
