using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.EntityFrameworkCore.Generators
{
    /// <summary>
    /// Guid value generator for PK
    /// </summary>
    public class GuidValueGenerator : ValueGenerator
    {
        /// <summary>
        /// GeneratesTemporaryValues
        /// </summary>
        public override bool GeneratesTemporaryValues => false;

        /// <summary>
        /// Generate value
        /// </summary>
        /// <param name="entry">
        /// Entry
        /// </param>
        /// <returns>
        /// Object
        /// </returns>
        protected override object NextValue(EntityEntry entry)
        {
            return Guid.NewGuid();
        }
    }
}
