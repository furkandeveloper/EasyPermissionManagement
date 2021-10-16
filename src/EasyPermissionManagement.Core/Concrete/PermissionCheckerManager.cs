using EasyPermissionManagement.Core.Abstractions;
using EasyPermissionManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Concrete
{
    /// <summary>
    /// Check Permission Manager
    /// </summary>
    public class PermissionCheckerManager : IPermissionChecker
    {
        private readonly IEasyPermissionContext context;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">
        /// Abstraction of Easy Permission Db Context
        /// </param>
        public PermissionCheckerManager(IEasyPermissionContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Check Permission
        /// </summary>
        /// <param name="permissionKey">
        /// Key of Permission
        /// </param>
        /// <param name="provider">
        /// Identifier Method
        /// </param>
        /// <param name="identifierKey">
        /// Identifier Key
        /// </param>
        /// <returns>
        /// Task of bool
        /// </returns>
        public virtual Task<bool> CheckAsync(string permissionKey, string provider, string identifierKey)
        {
            var permission = context.Get<Permission>().FirstOrDefault(a => a.Key == permissionKey && a.Provider == provider);
            
            if (permission is null)
            {
                throw new Exception($"Permission {permissionKey} not found");
            }

            return Task.FromResult(context.Get<IdentifierPermission>()
                .Any(a => a.PermissionId == permission.Id && a.IdentifierKey == identifierKey));
        }
    }
}
