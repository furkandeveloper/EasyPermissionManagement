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
    /// Assign or remove permissions to your data.
    /// </summary>
    public class PermissionProviderManager : IPermissionProvider
    {
        private readonly IEasyPermissionContext context;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">
        /// Abstraction of Easy Permission Db Context
        /// </param>
        public PermissionProviderManager(IEasyPermissionContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Apply Permission
        /// </summary>
        /// <param name="key">
        /// Key of Permission
        /// </param>
        /// <param name="provider">
        /// Identifier Method
        /// </param>
        /// <param name="identifierKey">
        /// The value to be identified.
        /// </param>
        public virtual async Task ApplyPermissionAsync(string key, string provider, string identifierKey)
        {
            var permission = context.Get<Permission>().FirstOrDefault(a => a.Key == key && a.Provider == provider);

            if (permission is null)
            {
                throw new Exception($"Permission {key} Not Found");
            }

            await context.InsertAsync<IdentifierPermission>(new IdentifierPermission
            {
                PermissionId = permission.Id,
                IdentifierKey = identifierKey
            });
        }

        /// <summary>
        /// Remove Permission
        /// </summary>
        /// <param name="key">
        /// Key of Permission
        /// </param>
        /// <param name="provider">
        /// Identifier Method
        /// </param>
        /// <param name="identifierKey">
        /// The value to be identified.
        /// </param>
        public virtual async Task RemovePermissionAsync(string key, string provider, string identifierKey)
        {
            var permission = context.Get<Permission>().FirstOrDefault(a => a.Key == key && a.Provider == provider);

            if (permission is null)
            {
                throw new Exception($"Permission {key} not found");
            }

            var identifierPermission = 
                context.Get<IdentifierPermission>()
                .FirstOrDefault(a => a.PermissionId == permission.Id && a.IdentifierKey == identifierKey);
            await context.DeleteAsync<IdentifierPermission>(identifierPermission);
        }
    }
}
