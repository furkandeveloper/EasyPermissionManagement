using EasyPermissionManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.PostgreSql.Context
{
    /// <summary>
    /// Easy Permission PostgreSql Db Context
    /// </summary>
    public class EasyPermissionPostgreSqlDbContext : EasyPermissionCoreDbContext
    {
        /// <summary>
        /// Protected Ctor
        /// </summary>
        public EasyPermissionPostgreSqlDbContext()
        {
        }

        /// <summary>
        /// Protected ctor
        /// </summary>
        /// <param name="options">
        /// The options to be used by a Microsoft.EntityFrameworkCore.DbContext. You normally override Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder) or use a Microsoft.EntityFrameworkCore.DbContextOptionsBuilder to create instances of this class and it is not designed to be directly constructed in your application code. 
        /// </param>
        public EasyPermissionPostgreSqlDbContext(DbContextOptions<EasyPermissionPostgreSqlDbContext> options) : base(options)
        {
        }
    }
}
