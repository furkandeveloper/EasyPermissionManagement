using EasyPermissionManagement.Core.Abstractions;
using EasyPermissionManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Concrete
{
    public class PermissionProviderManager : IPermissionProvider
    {
        private readonly IEasyPermissionContext context;

        public PermissionProviderManager(IEasyPermissionContext context)
        {
            this.context = context;
        }
        public virtual async Task ApplyPermissionAsync(string key, string identifierKey)
        {
            var permission = context.Get<Permission>().FirstOrDefault(a => a.Key == key);

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
    }
}
