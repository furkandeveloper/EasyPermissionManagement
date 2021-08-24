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
        public EasyPermissionPostgreSqlDbContext()
        {
        }

        public EasyPermissionPostgreSqlDbContext(DbContextOptions<EasyPermissionPostgreSqlDbContext> options) : base(options)
        {
        }
    }
}
