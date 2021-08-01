using EasyPermissionManagement.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Web.Permissions
{
    public class MyPermissionProvider : PermissionProvider
    {
        public override void Set(IPermissionDefinationContext context)
        {
            context.DefinePermission(key: "lead.create", provider: "User");
            base.Set(context);
        }
    }
}
