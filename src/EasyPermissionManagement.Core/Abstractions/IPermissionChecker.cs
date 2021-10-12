using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Abstractions
{
    /// <summary>
    /// Permission Checker
    /// </summary>
    public interface IPermissionChecker
    {
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
        Task<bool> CheckAsync(string permissionKey, string provider, string identifierKey);
    }
}
