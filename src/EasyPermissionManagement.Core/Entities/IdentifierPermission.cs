using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Entities
{
    public class IdentifierPermission : BaseEntity
    {
        public Guid PermissionId { get; set; }

        public string IdentifierKey { get; set; }

        /// <summary>
        /// Relation property
        /// </summary>
        public virtual Permission Permission { get; set; }
    }
}
