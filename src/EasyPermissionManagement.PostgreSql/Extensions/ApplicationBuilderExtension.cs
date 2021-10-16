using EasyPermissionManagement.PostgreSql.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.PostgreSql.Extensions
{
    /// <summary>
    /// This class includes Application Builder extensions for database migrations.
    /// Implements database migration.
    /// </summary>
    public static class ApplicationBuilderExtension
    {
        /// <summary>
        /// Database Migration for PostgreSql
        /// </summary>
        /// <param name="app">
        /// IApplicationBuilder
        /// </param>
        public static void UseEasyPermission(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<EasyPermissionPostgreSqlDbContext>();
                context.Database.Migrate();
            }
        }
    }
}
