using EasyPermissionManagement.Core.Abstractions;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using EasyPermissionManagement.Core.Statics;

namespace EasyPermissionManagement.Core.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void ApplyEasyPermission(this IApplicationBuilder app)
        {
            var type = typeof(PermissionProvider);
            var service = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
               .Where(p => type.IsAssignableFrom(p) && !p.IsInterface)
               .FirstOrDefault();

            var permissionDefinationContext = app.ApplicationServices.GetService<IPermissionDefinationContext>();

            if (service != null)
            {
                var instance = (PermissionProvider)Activator.CreateInstance(service);
                instance.Set(permissionDefinationContext);
            }
            if (PermissionValues.Permissions.Count > 0)
            {
                // Insert or Update permissions
                var context = app.ApplicationServices.GetRequiredService<IEasyPermissionContext>();
            }
        }
    }
}
