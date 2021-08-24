using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.PostgreSql.Context
{
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<EasyPermissionPostgreSqlDbContext>
    {
        public EasyPermissionPostgreSqlDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EasyPermissionPostgreSqlDbContext>();
            optionsBuilder.UseNpgsql("{YOUR_CONNECTION_STRING}");
            return new EasyPermissionPostgreSqlDbContext(optionsBuilder.Options);
        }
    }
}
