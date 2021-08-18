using EasyPermissionManagement.Core.Abstractions;
using EasyPermissionManagement.Core.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Concrete
{
    /// <summary>
    /// Permission Defination Context
    /// </summary>
    public class PermissionDefinationContext : IPermissionDefinationContext
    {
        public void DefinePermission(string key, string provider)
        {
            var permission = new PermissionValue(key, provider);

            PermissionValues.Permissions.Add(permission);
        }
    }
}
