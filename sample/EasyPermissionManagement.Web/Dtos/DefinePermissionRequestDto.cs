using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Web.Dtos
{
    /// <summary>
    /// Permission Request Data Transfer Object
    /// </summary>
    public class DefinePermissionRequestDto
    {
        /// <summary>
        /// Key of Permission
        /// </summary>
        public string PermissionKey { get; set; }

        /// <summary>
        /// Identifier Provider For Example; User, Organization etc.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Identifier Key
        /// </summary>
        public string IdentifierKey { get; set; }
    }
}
