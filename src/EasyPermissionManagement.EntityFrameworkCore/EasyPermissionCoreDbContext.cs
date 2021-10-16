using EasyPermissionManagement.Core.Abstractions;
using EasyPermissionManagement.Core.Entities;
using EasyPermissionManagement.EntityFrameworkCore.Generators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.EntityFrameworkCore
{
    /// <summary>
    /// Easy Permission Core DbContext
    /// </summary>
    public abstract class EasyPermissionCoreDbContext : DbContext, IEasyPermissionContext
    {
        /// <summary>
        /// Protected Ctor
        /// </summary>
        protected EasyPermissionCoreDbContext()
        {
        }

        /// <summary>
        /// Protected ctor
        /// </summary>
        /// <param name="options">
        /// The options to be used by a Microsoft.EntityFrameworkCore.DbContext. You normally override Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder) or use a Microsoft.EntityFrameworkCore.DbContextOptionsBuilder to create instances of this class and it is not designed to be directly constructed in your application code. 
        /// </param>
        protected EasyPermissionCoreDbContext(DbContextOptions options) : base(options)
        {
        }

        #region Tables
        /// <summary>
        /// Permission Entity
        /// </summary>
        public virtual DbSet<Permission> Permissions { get; set; }

        /// <summary>
        /// Identifier Permission
        /// </summary>
        public virtual DbSet<IdentifierPermission> IdentifierPermissions { get; set; }
        #endregion

        /// <summary>
        /// On Model Creating
        /// </summary>
        /// <param name="modelBuilder">
        /// Provides a simple API surface for configuring a Microsoft.EntityFrameworkCore.Metadata.IMutableModel
        /// that defines the shape of your entities, the relationships between them, and
        /// how they map to the database.
        /// You can use Microsoft.EntityFrameworkCore.ModelBuilder to construct a model for
        /// a context by overriding Microsoft.EntityFrameworkCore.DbContext.OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder)
        /// on your derived context. Alternatively you can create the model externally and
        /// set it on a Microsoft.EntityFrameworkCore.DbContextOptions instance that is passed
        /// to the context constructor.
        /// </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Permission>(entity =>
            {
                entity
                    .ToTable(nameof(Permissions), "easy-permissions");

                entity
                    .HasKey(pk => pk.Id);

                entity
                    .HasIndex(ix=> new{ ix.CreateDate, ix.UpdateDate, ix.Key, ix.Provider });

                entity
                    .Property(p => p.Key)
                    .IsRequired();

                entity
                    .Property(p => p.Provider)
                    .IsRequired();

                entity
                    .Property(p => p.CreateDate)
                    .HasValueGenerator<DateTimeValueGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .Property(p => p.UpdateDate)
                    .HasValueGenerator<DateTimeValueGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .Property(p => p.Id)
                    .HasValueGenerator<GuidValueGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .HasMany(m => m.IdentifierPermissions)
                    .WithOne(o => o.Permission)
                    .HasForeignKey(fk => fk.PermissionId);
            });

            modelBuilder.Entity<IdentifierPermission>(entity =>
            {
                entity
                    .ToTable(nameof(IdentifierPermissions), "easy-permissions");

                entity
                    .HasKey(pk=>pk.Id);

                entity
                    .HasIndex(ix=> new { ix.CreateDate, ix.UpdateDate, ix.IdentifierKey});

                entity
                    .Property(p=>p.IdentifierKey)
                    .IsRequired();

                entity
                    .Property(p => p.CreateDate)
                    .HasValueGenerator<DateTimeValueGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .Property(p => p.UpdateDate)
                    .HasValueGenerator<DateTimeValueGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .Property(p => p.Id)
                    .HasValueGenerator<GuidValueGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .HasOne(o => o.Permission)
                    .WithMany(m => m.IdentifierPermissions)
                    .HasForeignKey(fk => fk.PermissionId);
            });
        }

        /// <summary>
        /// Get Queryable Entity
        /// </summary>
        /// <typeparam name="T">
        /// Type of Entity
        /// </typeparam>
        /// <returns>
        /// Type of IQueryable
        /// </returns>
        public IQueryable<T> Get<T>() where T : class
        {
            return Set<T>().AsQueryable();
        }

        /// <summary>
        /// Insert Entity
        /// </summary>
        /// <typeparam name="T">
        /// Type of Entity
        /// </typeparam>
        /// <param name="entity">
        /// Entity
        /// </param>
        /// <returns>
        /// Task
        /// </returns>
        public virtual async Task<T> InsertAsync<T>(T entity) where T : class
        {
            var entry = Entry(entity);
            entry.State = EntityState.Added;
            await SaveChangesAsync();
            return entry.Entity;
        }

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <typeparam name="T">
        /// Type of Entity
        /// </typeparam>
        /// <param name="entity">
        /// Entity
        /// </param>
        /// <returns>
        /// Task
        /// </returns>
        public virtual async Task<T> UpdateAsync<T>(T entity) where T : class
        {
            var entry = Entry(entity);
            entry.State = EntityState.Modified;
            await SaveChangesAsync();
            return entry.Entity;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <typeparam name="T">
        /// Type of Entity
        /// </typeparam>
        /// <param name="entity">
        /// Entity
        /// </param>
        /// <returns>
        /// Task
        /// </returns>
        public virtual async Task DeleteAsync<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
            await SaveChangesAsync();
        }

        /// <summary>
        /// Insert Entity
        /// </summary>
        /// <typeparam name="T">
        /// Type of Entity
        /// </typeparam>
        /// <param name="entity">
        /// Entity
        /// </param>
        /// <returns>
        /// Entity
        /// </returns>
        public virtual T Insert<T>(T entity) where T : class
        {
            var entry = Entry(entity);
            entry.State = EntityState.Added;
            SaveChanges();
            return entry.Entity;
        }

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <typeparam name="T">
        /// Type of Entity
        /// </typeparam>
        /// <param name="entity">
        /// Entity
        /// </param>
        /// <returns>
        /// Entity
        /// </returns>
        public virtual T Replace<T>(T entity) where T : class
        {
            var entry = Entry(entity);
            entry.State = EntityState.Modified;
            SaveChanges();
            return entry.Entity;
        }

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <typeparam name="T">
        /// Type of Entity
        /// </typeparam>
        /// <param name="entity">
        /// Entity
        /// </param>
        public virtual void Delete<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
            SaveChangesAsync();
        }
    }
}
