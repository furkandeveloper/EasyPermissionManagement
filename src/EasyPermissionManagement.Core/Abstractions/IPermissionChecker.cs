using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Abstractions
{
    public interface IPermissionChecker
    {
        Task<bool> CheckAsync(string permissionKey, string provider, string identifierKey);
    }
}
