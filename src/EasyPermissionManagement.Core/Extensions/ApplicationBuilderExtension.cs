using EasyPermissionManagement.Core.Abstractions;
using EasyPermissionManagement.Core.Entities;
using EasyPermissionManagement.Core.Statics;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

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
                // Insert or Delete permissions
                var context = app.ApplicationServices.GetRequiredService<IEasyPermissionContext>();
                var permissionList = context.Get<Permission>().ToList();
                foreach (var permission in PermissionValues.Permissions)
                {
                    var findedPermission = permissionList.FirstOrDefault(a => a.Key == permission.Key && a.Provider == permission.Provider);
                    if (findedPermission is null)
                    {
                        // Insert
                        context.Insert<Permission>(new Permission { Provider = permission.Provider, Key = permission.Key });
                    }
                }
                var permissionSelectedList = permissionList.Select(s => new
                {
                    Key = s.Key,
                    Provider = s.Provider
                }).ToList();

                var definedSelectedList = PermissionValues.Permissions.Select(s => new
                {
                    Key = s.Key,
                    Provider = s.Provider
                }).ToList();

                var deletedPermissions = permissionSelectedList.Except(definedSelectedList).ToList();

                foreach (var permission in deletedPermissions)
                {
                    // Delete
                    context.Delete<Permission>(permissionList.FirstOrDefault(a=>a.Key == permission.Key && a.Provider == permission.Provider));
                }
            }
        }
    }
}
