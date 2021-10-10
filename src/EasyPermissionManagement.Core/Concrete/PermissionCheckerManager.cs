using EasyPermissionManagement.Core.Abstractions;
using EasyPermissionManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Concrete
{
    public class PermissionCheckerManager : IPermissionChecker
    {
        private readonly IEasyPermissionContext context;

        public PermissionCheckerManager(IEasyPermissionContext context)
        {
            this.context = context;
        }
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
