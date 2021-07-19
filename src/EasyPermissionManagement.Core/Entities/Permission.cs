using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Entities
{
    /// <summary>
    /// Permission
    /// </summary>
    public class Permission : BaseEntity
    {
        /// <summary>
        /// Name of Permission
        /// </summary>
        public string Key { get; set; }


        /// <summary>
        /// Provider of Permission
        /// </summary>
        public string Provider { get; set; }
    }
}
