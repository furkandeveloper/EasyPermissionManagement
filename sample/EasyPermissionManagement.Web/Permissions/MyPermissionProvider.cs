using EasyPermissionManagement.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Web.Permissions
{
    /// <summary>
    /// My Permission Provider
    /// </summary>
    public class MyPermissionProvider : PermissionProvider
    {
        /// <summary>
        /// Set Default Permissions
        /// </summary>
        /// <param name="context">
        /// Permission Defination Context
        /// </param>
        public override void Set(IPermissionDefinationContext context)
        {
            // LEAD for User
            context.DefinePermission(key: "lead.create", provider: "User");
            context.DefinePermission(key: "lead.delete", provider: "User");
            context.DefinePermission(key: "lead.read", provider: "User");
            context.DefinePermission(key: "lead.update", provider: "User");
            
            // CUSTOMER for User
            context.DefinePermission(key: "customer.delete", provider: "User");
            context.DefinePermission(key: "customer.update", provider: "User");
            context.DefinePermission(key: "customer.create", provider: "User");
            context.DefinePermission(key: "customer.read", provider: "User");

            // LEAD for Organization
            context.DefinePermission(key: "lead.create", provider: "Organization");
            context.DefinePermission(key: "lead.delete", provider: "Organization");
            context.DefinePermission(key: "lead.read", provider: "Organization");
            context.DefinePermission(key: "lead.update", provider: "Organization");

            // CUSTOMER for Organization
            context.DefinePermission(key: "customer.delete", provider: "Organization");
            context.DefinePermission(key: "customer.update", provider: "Organization");
            context.DefinePermission(key: "customer.create", provider: "Organization");
            context.DefinePermission(key: "customer.read", provider: "Organization");

            base.Set(context);
        }
    }
}
