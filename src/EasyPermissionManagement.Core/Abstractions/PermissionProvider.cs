using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Abstractions
{
    /// <summary>
    /// Permission Provider
    /// </summary>
    public abstract class PermissionProvider
    {
        /// <summary>
        /// Set Permission
        /// </summary>
        /// <param name="context">
        /// Permission Defination Context
        /// </param>
        public virtual void Set(IPermissionDefinationContext context)
        {

        }
    }
}
