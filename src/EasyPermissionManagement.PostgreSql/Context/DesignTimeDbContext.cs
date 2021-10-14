using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.PostgreSql.Context
{
    /// <summary>
    /// Design Time Db Context For EasyPermissionPostgreSqlDbContext
    /// </summary>
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<EasyPermissionPostgreSqlDbContext>
    {
        /// <summary>
        /// Create DbContext
        /// </summary>
        public EasyPermissionPostgreSqlDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EasyPermissionPostgreSqlDbContext>();
            optionsBuilder.UseNpgsql("{YOUR_CONNECTION_STRING}");
            return new EasyPermissionPostgreSqlDbContext(optionsBuilder.Options);
        }
    }
}
