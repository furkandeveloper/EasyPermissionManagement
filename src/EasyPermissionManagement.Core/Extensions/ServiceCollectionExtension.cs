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
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddEasyPermission(this IServiceCollection services)
        {
            services.AddTransient<IPermissionDefinationContext, PermissionDefinationContext>();
            services.AddTransient<IPermissionProvider, PermissionProviderManager>();
            return services;
        }
    }
}
