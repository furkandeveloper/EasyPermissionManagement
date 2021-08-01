using EasyPermissionManagement.Core.Entities;
using EasyPermissionManagement.Core.Extensions;
using EasyPermissionManagement.Core.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Abstractions
{
    public interface IPermissionDefinationContext
    {
        void DefinePermission(string key, string provider);
    }
}
