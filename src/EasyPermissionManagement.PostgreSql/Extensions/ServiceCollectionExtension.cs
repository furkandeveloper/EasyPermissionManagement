using EasyPermissionManagement.Core.Abstractions;
using EasyPermissionManagement.PostgreSql.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.PostgreSql.Extensions
{
    /// <summary>
    /// Service Collection Extensions for PostgreSql implementation
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Initialize Easy Permission
        /// </summary>
        /// <param name="services">
        /// IServiceCollection
        /// </param>
        /// <param name="options">
        /// Action of DbContextOptionsBuilder
        /// </param>
        /// <returns>
        /// IServiceCollection
        /// </returns>
        public static IServiceCollection UseEasyPermissionNpgsql(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<EasyPermissionPostgreSqlDbContext>(options, ServiceLifetime.Transient, ServiceLifetime.Transient);
            services.AddTransient<IEasyPermissionContext>(sp => sp.GetService<EasyPermissionPostgreSqlDbContext>());
            return services;
        }
    }
}
