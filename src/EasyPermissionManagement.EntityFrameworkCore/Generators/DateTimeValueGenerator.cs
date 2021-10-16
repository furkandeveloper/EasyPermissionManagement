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
    /// Date Time Value Generator
    /// </summary>
    public class DateTimeValueGenerator : ValueGenerator
    {
        /// <summary>
        /// GeneratesTemporaryValues
        /// </summary>
        public override bool GeneratesTemporaryValues => false;

        /// <summary>
        /// Generate value
        /// </summary>
        /// <param name="entry">
        /// Provides access to change tracking information and operations for a given entity.
        /// Instances of this class are returned from methods when using the Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker</param>
        /// API and it is not designed to be directly constructed in your application code.
        /// <returns>
        /// Object
        /// </returns>
        protected override object NextValue(EntityEntry entry)
        {
            return DateTime.UtcNow;
        }
    }
}
