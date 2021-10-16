using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Entities
{
    /// <summary>
    /// Base Entity
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// PK
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Create Date of row
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Update date of row
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}
