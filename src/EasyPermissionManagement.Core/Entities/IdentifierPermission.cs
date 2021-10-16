using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Entities
{
    /// <summary>
    /// Identifier Permission Entitiy
    /// </summary>
    public class IdentifierPermission : BaseEntity
    {
        /// <summary>
        /// FK of Permission
        /// </summary>
        public Guid PermissionId { get; set; }

        /// <summary>
        /// Identifier Key
        /// </summary>
        public string IdentifierKey { get; set; }

        /// <summary>
        /// Relation property
        /// </summary>
        public virtual Permission Permission { get; set; }
    }
}
