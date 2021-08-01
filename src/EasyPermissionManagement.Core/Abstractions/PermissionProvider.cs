using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Abstractions
{
    public abstract class PermissionProvider
    {
        public virtual void Set(IPermissionDefinationContext context)
        {

        }
    }
}
