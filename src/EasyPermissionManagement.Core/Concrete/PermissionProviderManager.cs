﻿using EasyPermissionManagement.Core.Abstractions;
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